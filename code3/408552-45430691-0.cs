    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    
    namespace MultipleCheckBoxesApp
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            string _concateString = "";
            private void checkBoxButton_Click(object sender, EventArgs e)
            {
                List<string> ourList = new List<string>();
                if (csharpCheckBox.Checked)
                {
                    ourList.Add(csharpCheckBox.Text);
                }
                if (javaCheckBox.Checked)
                {
                    ourList.Add(javaCheckBox.Text);
                }
                if (cCheckBox.Checked)
                {
                    ourList.Add(cCheckBox.Text);
                }
                if (phpCheckBox.Checked)
                {
                    ourList.Add(phpCheckBox.Text);
                }
                if (cplusCheckBox.Checked)
                {
                    ourList.Add(cplusCheckBox.Text);
                }
                foreach (string checkList in ourList)
                {
                    _concateString += checkList + " ,";
                }
                if (_concateString == string.Empty)
                {
                    MessageBox.Show("Nothing Checked", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    MessageBox.Show(_concateString + " has been checked");
                }
    
                ourList.Clear();
                _concateString = string.Empty;
    
    
    
            }
        }
    }
