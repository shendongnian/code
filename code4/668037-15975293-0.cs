    namespace OddFormTest
    {
        using System;
        using System.Windows.Forms;
        public class OddForm : Form
        {
            public OddForm()
            {
                this.Leave += Leaver;
            }
            [STAThread]
            internal static void Main()
            {
                Application.Run(new OddForm);
            }
            private void Leave(object sender, EventArgs e)
            {
                this.Close()
            }
        }
    }
