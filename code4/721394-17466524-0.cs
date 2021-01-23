    public class BorderedTextBox : Panel 
    {
        private TextBox textBox;
        private bool focusedAlways = false;
        private Color normalBorderColor = Color.Gray;
        private Color focusedBorderColor = Color.Red;
        public BorderTextBox() 
        {
            this.DoubleBuffered = true;
            this.Padding = new Padding(2);
            this.TextBox = new TextBox();
            this.TextBox.AutoSize = false;
            this.TextBox.BorderStyle = BorderStyle.None;
            this.TextBox.Dock = DockStyle.Fill;
            this.TextBox.Enter += new EventHandler(this.TextBox_Refresh);
            this.TextBox.Leave += new EventHandler(this.TextBox_Refresh);
            this.TextBox.Resize += new EventHandler(this.TextBox_Refresh);
            this.Controls.Add(this.TextBox);
        }
        private void TextBox_Refresh(object sender, EventArgs e) 
        {
            this.Invalidate();
        }
        protected override void OnPaint(PaintEventArgs e) 
        {
            e.Graphics.Clear(SystemColors.Window);
            using (Pen borderPen = new Pen(this.TextBox.Focused || FocusedAlways ? 
                focusedBorderColor : normalBorderColor)) 
            {
                e.Graphics.DrawRectangle(borderPen, 
                    new Rectangle(0, 0, this.ClientSize.Width - 1, this.ClientSize.Height - 1));
            }
            base.OnPaint(e);
        }
        public TextBox TextBox
        {
            get { return textbox; }
            set { textbox = value; }
        }
        public bool FocusedAlaways
        {
            get { return focusedAlways; }
            set { focusedAlways = value; }
        }
    }
