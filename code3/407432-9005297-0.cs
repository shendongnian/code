    /// <summary>
    /// Ferries writes from a non-UI component to a TextBoxBase object. The writes originate
    /// on a non-UI thread, while the destination TextBoxBase object can only be written
    /// from the UI thread.
    /// 
    /// Furthermore, we want to batch writes in ~50 ms chunks so as to write to the UI as little as
    /// possible.
    /// 
    /// This classes uses a Forms Timer (so that the timer fires from the UI thread) to create
    /// write chunks from the inter-thread buffer to write to the TextBoxBase object.
    /// </summary>
    public class TextBoxBuffer
    {
        private RingBuffer<string> buffer;
        private TextBoxBase textBox;
        private System.Windows.Forms.Timer formTimer;
        StringBuilder builder;
        public TextBoxBuffer( TextBoxBase textBox )
        {
            this.textBox = textBox;
            buffer = new RingBuffer<string>( 500 );
            builder = new StringBuilder( 500 );
            this.formTimer = new System.Windows.Forms.Timer();
            this.formTimer.Tick += new EventHandler( formTimer_Tick );
            this.formTimer.Interval = 50;
        }
        public void Start()
        {
            this.formTimer.Start();
        }
        public void Shutdown()
        {
            this.formTimer.Stop();
            this.formTimer.Dispose();
        }
        public void Write( string text )
        {
            buffer.EnqueueBlocking( text );
        }
        private void formTimer_Tick( object sender, EventArgs e )
        {
            while( WriteChunk() ) {}
            Trim();
        }
        /// <summary>
        /// Reads from the inter-thread buffer until
        /// 1) The buffer runs out of data
        /// 2) More than 50 ms has elapsed
        /// 3) More than 5000 characters have been read from the buffer.
        /// 
        /// And then writes the chunk directly to the textbox.
        /// </summary>
        /// <returns>Whether or not there is more data to be read from the buffer.</returns>
        private bool WriteChunk()
        {
            string line = null;
            int start;
            bool moreData;
            builder.Length = 0;
            start = Environment.TickCount;
            while( true )
            {
                moreData = buffer.Dequeue( ref line, 0 );
                if( moreData == false ) { break; }
                builder.Append( line );
                if( Environment.TickCount - start > 50 ) { break; }
                if( builder.Length > 5000 ) { break; }
            }
            if( builder.Length > 0 )
            {
                this.textBox.AppendText( builder.ToString() );
                builder.Length = 0;
            }
            return moreData;
        }
        private void Trim()
        {
            if( this.textBox.TextLength > 100 * 1000 )
            {
                string[] oldLines;
                string[] newLines;
                int newLineLength;
                oldLines = this.textBox.Lines;
                newLineLength = oldLines.Length / 3;
                newLines = new string[newLineLength];
                for( int i = 0; i < newLineLength; i++ )
                {
                    newLines[i] = oldLines[oldLines.Length - newLineLength + i];
                }
                this.textBox.Lines = newLines;
            }
        }
    }
