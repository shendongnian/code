    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void button1_Click(object sender, EventArgs e)
            {
                var result = from num in this.checkedListBox1.CheckedItems.OfType<string>()
                             select Convert.ToInt32(num);
                this.textBox1.Text = result.Sum().ToString();
            }
        }
    }
