    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;
    
    namespace TestApplication2
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                Form1.LoadXmlFromServerToProgram();
    
                MessageBox.Show(string.Concat("Email: ", Email, "\r\n", "UserName: ", UserName, "\r\n", "Password: ", Password));
            }
    
            public static string Email { get; set; }
            public static string UserName { get; set; }
            public static string Password { get; set; }
    
            private static void LoadXmlFromServerToProgram()
            {
                try
                {
                    XmlDocument xDoc = new XmlDocument();
                    xDoc.Load("http://www.ad-net.co.il/test.asp");
    
                    Email = xDoc.DocumentElement.SelectSingleNode("EMAIL").InnerText;
                    UserName = xDoc.DocumentElement.SelectSingleNode("USERNAME").InnerText;
                    Password = xDoc.DocumentElement.SelectSingleNode("PASSWORD").InnerText;
                }
                catch
                {
                    MessageBox.Show("Can't Read From XML");
                }
            }
        }
    
        partial class Form1
        {
            /// <summary>
            /// Required designer variable.
            /// </summary>
            private System.ComponentModel.IContainer components = null;
    
            /// <summary>
            /// Clean up any resources being used.
            /// </summary>
            /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
            protected override void Dispose(bool disposing)
            {
                if (disposing && (components != null))
                {
                    components.Dispose();
                }
                base.Dispose(disposing);
            }
    
            #region Windows Form Designer generated code
    
            /// <summary>
            /// Required method for Designer support - do not modify
            /// the contents of this method with the code editor.
            /// </summary>
            private void InitializeComponent()
            {
                this.SuspendLayout();
                // 
                // Form1
                // 
                this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                this.ClientSize = new System.Drawing.Size(284, 262);
                this.Name = "Form1";
                this.Text = "Form1";
                this.Load += new System.EventHandler(this.Form1_Load);
                this.ResumeLayout(false);
    
            }
    
            #endregion
        }
    }
