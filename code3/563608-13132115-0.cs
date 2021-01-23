        void Control_MouseLeave(object sender, System.Windows.Input.MouseEventArgs e)
        {
            WPFHelper.EnumerateChildren<TextBlock>(this, true).ForEach(c => c.TextDecorations = null);
        }
        void Control_MouseEnter(object sender, System.Windows.Input.MouseEventArgs e)
        {
            WPFHelper.EnumerateChildren<TextBlock>(this, true).ForEach(c => c.TextDecorations = TextDecorations.Underline);
        }
