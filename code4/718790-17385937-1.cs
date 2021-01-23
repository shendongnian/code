    public static class CheckboxDialog
    {   
        public static bool ShowDialog(string text, string caption)
        {
            Form prompt = new Form();
            prompt.Width = 180;
            prompt.Height = 100;
            prompt.Text = caption;
            FlowLayoutPanel panel = new FlowLayoutPanel();
            CheckBox chk = new CheckBox();
            chk.Text = text;
            Button ok = new Button() { Text = "Yes" };
            ok.Click += (sender, e) => { prompt.Close(); };
            Button no = new Button() { Text = "No" };
            no.Click += (sender, e) => { prompt.Close(); };
            panel.Controls.Add(chk);
            panel.SetFlowBreak(chk, true);
            panel.Controls.Add(ok);
            panel.Controls.Add(no);
            prompt.Controls.Add(panel);
            prompt.ShowDialog();
            return chk.Checked;
        }
    }
