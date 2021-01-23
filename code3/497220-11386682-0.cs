    namespace Test
    {
        public partial class Form1 : Form
        {
            private Form2 form2;
            public Form1()
            {
                InitializeComponent();
                form2 = new Form2();
            }
            private void runCheck(object source, System.Timers.ElapsedEventArgs e)
            {
                if (form2.InvokeRequired)
                {
                    form2.Invoke(new EventHandler(delegate { form2.ShowDialog(); form2.TopMost = true; }));
                }
                else
                {
                    form2.ShowDialog(); 
                    form2.TopMost = true;
                }
            }
            private void runCheckFalse()
            {
                if(form2.InvokeRequired)
                {
                    form2.Invoke(new EventHandler(delegate { form2.Hide(); }));
                }
                else
                {
                    form2.Hide();
                }
            }
        }
    }
