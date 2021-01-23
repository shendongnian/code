    public static class CheckboxDialog
    {
        public static bool ShowDialog(string text, string caption)
        {
            Form prompt = new Form();
            prompt.Width = 250;
            prompt.Height = 100;
            prompt.Text = caption;
            FlowLayoutPanel panel = new FlowLayoutPanel();
            CheckBox chk = new CheckBox();
            chk.Text = text;
            Button ok = new Button() { Text = "Ok" };
            ok.Click += (sender, e) => { prompt.Close(); };
            panel.Controls.Add(chk);
            panel.Controls.Add(ok);
            prompt.Controls.Add(panel);
            prompt.ShowDialog();
            return chk.Checked;
        }
    }
