    using ext;
    
    namespace ext
    {
        public static class extensions
        {
            public static DialogResult ShowDialog(this Form form, string title)
            {
                DialogResult ret;
    
    
                form.Text = title;
    
                ret = form.ShowDialog();
    
                return ret;
            }
        }
    }
