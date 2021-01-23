        public Form1()
        {
            InitializeComponent();
            // Allow TextBoxB to accept a drop.
            TextBoxB.AllowDrop = true;
            // Add event handlers to manage the drag drop action.
            TextBoxB.DragEnter += TextBoxB_DragEnter;
            TextBoxB.DragDrop += TextBoxB_DragDrop;
        }
        void TextBoxB_DragEnter(object sender, DragEventArgs e)
        {
            // Update cursor to inform user of drag drop action.
            if (e.Data.GetDataPresent(DataFormats.Text)) e.Effect = DragDropEffects.Copy;
        }
        void TextBoxB_DragDrop(object sender, DragEventArgs e)
        {
            // Get the current cursor postion within the control.
            var point =TextBoxB.PointToClient(Cursor.Position);
            // Find the character index based on cursor position.
            var pos = TextBoxB.GetCharIndexFromPosition(point);
            // Insert the required text into the control.
            TextBoxB.Text = TextBoxB.Text.Insert(pos, TextBoxA.Text);
        }
