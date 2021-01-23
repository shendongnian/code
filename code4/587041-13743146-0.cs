        private void timer1_Tick( object sender, EventArgs e )
        {
            // peek the data of a custom type
            object o = Clipboard.GetData( "custom" );
            if ( o != null )
            {
                // do whatever you want with the data
                textBox1.Text = o.ToString();
                // clear the clipboard
                Clipboard.Clear();
            }
        }
