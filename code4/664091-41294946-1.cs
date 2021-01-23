    public class ButtonTextBox : TextBox
    {
        Button button;
        public ButtonTextBox()
        {
            this.button = new Button();
            this.button.Dock = DockStyle.Right;
            this.button.BackColor = SystemColors.Control;
            this.button.Width = 21;
            this.Controls.Add(this.button);
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            
            switch (m.Msg)
            {
                case 0x30:
                    int num = this.button.Width + 3;
                    this.SendMessage(0xd3, 2, num << 16);
                    return;
            }
        }
    }
