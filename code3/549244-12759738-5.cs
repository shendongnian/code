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
                this.KeyDown +=new KeyEventHandler(Form1_KeyDown);
            }
            void  Form1_KeyDown(object sender, KeyEventArgs e)
            {
                if (e.KeyCode.Equals(Keys.Enter))  //Invokes whenever Enter is pressed
                {
                    btnLogin_Click(sender, e);  //login
                }
            }
            private void btnLogin_Click(object sender, EventArgs e)
            {
                if (txtUserName.Text.Equals("Administrator") && txtPassword.Text.Equals("123"))
                {
                    MessageBox.Show("Administrator");
                }
                else if (txtUserName.Text.Equals("Clerk") && txtPassword.Text.Equals("123"))
                {
                    MessageBox.Show("Clerk");
                }
                else
                {
                    MessageBox.Show("Please Enter correct details", "Login Error");
                }
            }
        }
    }
