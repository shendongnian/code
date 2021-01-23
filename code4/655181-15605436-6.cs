    using System;
    using System.Windows.Forms;
    namespace WindowsFormsApplication1
    {
        public partial class Form2: Form
        {
            public event EventHandler CheckBoxChanged;
            public Form2()
            {
                InitializeComponent();
            }
            private void checkBox1_CheckedChanged(object sender, EventArgs e)
            {
                var handler = CheckBoxChanged;
                if (handler != null)
                    handler(sender, e);
            }
        }
    }
