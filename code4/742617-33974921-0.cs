    using System;
    using System.Windows.Forms;
    using System.Globalization;
    
    namespace TestingTextBoxAutoLangSwitch
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            
            // Switching to Arabic Jordan
            private void textBox2_Enter_1(object sender, EventArgs e)
            {
                Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("ar-jo"));
            }
    
            // Switching back to English USA
            private void textBox2_Leave(object sender, EventArgs e)
            {
                Application.CurrentInputLanguage = InputLanguage.FromCulture(new CultureInfo("en-us"));
            }
        }
    }
