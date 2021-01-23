        TextBox[] text = new TextBox[20]; //these are your new textboxes
        private void Form1_Load(object sender, EventArgs e)
        {
            for(int i=0; i<text.Length;i++) text[i] = new TextBox() {Text="0"}; //initialize each textbox
            tableLayoutPanel1.Controls.AddRange(text); //add textboxes to the tablelayoutpanel
            for(int i = 0; i<tableLayoutPanel1.Controls.Count;i++) //add everything in the tablelayoutpanel to the same keydown event
            tableLayoutPanel1.Controls[i].KeyDown+=new KeyEventHandler(tableLayoutPanel1_KeyDown);
        }
        void tableLayoutPanel1_KeyDown(object sender, KeyEventArgs e)
        { // this moves the box focus up down left or right 
            if (e.KeyData == Keys.Left)
                for (int i = 0; i < text.Length; i++)
                {
                    if (sender.Equals(text[i]))
                    { text[i - 1 < 0 ? text.Length - 1 : i - 1].Focus(); break; }
                }
             else if (e.KeyData == Keys.Right)
                for (int i = 0; i < text.Length; i++)
                {
                    if (sender.Equals(text[i]))
                    { text[i + 1 > text.Length - 1 ? 0 : i + 1].Focus(); break; }
                }
             else if (e.KeyData == Keys.Up)
                 for (int i = 0; i < text.Length; i++)
                 {
                     if (sender.Equals(text[i]))
                     { text[i - 4 < 0 ? i - 4 + text.Length : i - 4].Focus(); break; }
                 }
             else if (e.KeyData == Keys.Down)
                 for (int i = 0; i < text.Length; i++)
                 {
                     if (sender.Equals(text[i]))
                     { text[i + 4 > text.Length - 1 ? i + 4 - text.Length : i + 4].Focus(); break; }
                 }
        }
