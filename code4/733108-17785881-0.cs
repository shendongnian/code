    public static class ControlExt
    {
        public static void SetText(this Control self, object obj)
        {
            self.Text = obj.ToString();
        }
    }
