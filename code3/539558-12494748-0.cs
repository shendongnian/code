    using System;
    using System.Windows.Forms;
    namespace FormComm
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
            private void button1_Click(object sender, EventArgs e)
            {
                var form2 = new Form2(this);
                form2.Show();
            }
            delegate void AddListBoxItemCallback(string text);
            public void AddListBoxItem(object item)
            {
                if (this.InvokeRequired)
                {
                    AddListBoxItemCallback callback = new AddListBoxItemCallback(AddListBoxItem);
                    this.Invoke(callback, new object[] { item });
                }
                else
                {
                    this.listBox1.Items.Add(item);
                }
            }
        }
    }
