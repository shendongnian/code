    public class MyForm
    {
        private static MyForm form = null;
        public static bool? EnableTextBox1
        {
            get 
            {
                if (form == null)
                    return null;
                else
                    return form.textBox1.Enabled;
            }
            set
            {
                if (form == null)
                    return;
                form.textBox1.Enabled = (bool)value;
            }
        }
        public MyForm()
        {
            form = this;
        }
    }
