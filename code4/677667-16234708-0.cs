     using System;
     using System.Collections.Generic;
     using System.ComponentModel;
     using System.Data;
     using System.Drawing;
     using System.Linq;
     using System.Text;
     using System.Threading.Tasks;
     using System.Windows.Forms;
     namespace WindowsFormsApplication1
      {
    public partial class Form1 : Form
    {
        // Declare Global Variable
        DataHolder objDataHolder = new DataHolder();
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            // Here use your code to load the data retrieved from Microprocessor
            objDataHolder.UserData = txtUserData.Text;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            MessageBox.Show(objDataHolder.UserData);
        }
    }
    // Class to hold Data 
    public class DataHolder
    {
        // Here have a list variables that you need to maintain that are retrieved from Microrocessor.
        private string _userdata = string.Empty;
        // Here have a list Properties that you need to maintain that are retrieved from Microrocessor.
        public string UserData
        {
            get
            {
                return _userdata;
            }
            set
            {
                _userdata = value;
            }
        }
    }
}
