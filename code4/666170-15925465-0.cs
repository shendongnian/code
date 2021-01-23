    class CustomButton : Button
    {
        protected override void OnPaint(PaintEventArgs pevent)
        {
            TextBox tb = new TextBox();
            tb.Width = 100;
            tb.Height = 20;
            tb.Top = this.Top - 20;
            tb.Left = this.Left;
            this.Parent.Controls.Add(tb);
            base.OnPaint(pevent);
        }
    }
