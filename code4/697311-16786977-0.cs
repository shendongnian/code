      public partial class UserControl1 : UserControl
        {
            private string text;
            public string Text
            {
                get { return textBox.Text; }
                set { textBox.Text = value; }
            }
            TextBox textBox = new TextBox();
            public UserControl1()
            {
                InitializeComponent();
                this.Paint += new PaintEventHandler(UserControl1_Paint);
                this.Resize += new EventHandler(UserControl1_Resize);
                textBox.Multiline = true;
                textBox.BorderStyle = BorderStyle.None;
                this.Controls.Add(textBox);
            }
            private void UserControl1_Resize(object sender, EventArgs e)
            {
                textBox.Size = new Size(this.Width - 3, this.Height - 2);
                textBox.Location = new Point(2, 1);
            }
            private void UserControl1_Paint(object sender, PaintEventArgs e)
            {
                ControlPaint.DrawBorder(e.Graphics, this.ClientRectangle, Color.Red, ButtonBorderStyle.Solid);
            }
        }
