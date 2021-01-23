    using System;
    using System.Windows.Forms;
    namespace FormComm
    {
        public partial class Form2 : Form
        {
            private Form1 _form = null;
            public Form2(Form1 form)
            {
                InitializeComponent();
                this._form = form;
            }
            private void button1_Click(object sender, EventArgs e)
            {
                _form.AddListBoxItem(textBox1.Text);
            }
        }
    }
