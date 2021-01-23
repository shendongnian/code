     public class FormKeyListener
        {
            private Form formToListen = null;
            public void SetFormToListen(Form form)
            {
    
                if (formToListen != null)
                    formToListen.KeyDown -= formToListen_KeyDown; // Unregister from old form if present
    
                formToListen = form;
                formToListen.KeyDown += formToListen_KeyDown; // Attach to new form
            }
    
            void formToListen_KeyDown(object sender, KeyEventArgs e)
            {
                MessageBox.Show(e.KeyValue.ToString());
            }
        }
