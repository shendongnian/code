    public class ControlTester : IDisposable
    {
        private Form _form = new Form();
    
        public ControlTester(Control control)
        {
            _form = new Form();
            _form.Controls.Add(control);
            _form.Show();
        }
    
        public void Dispose()
        {
            _form.Close();
        }
    }
