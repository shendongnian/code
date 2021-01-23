    using System;
    using System.Linq;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Text;
    using System.Windows.Forms;
    namespace FormInstance
    {
        public partial class Form1 : Form
        {
            private static Form1 instance = null;
            public static Form1 GetInstance()
            {
                if (instance == null)
                    instance = new Form1();
                return instance;
            }
            
            public Form1()
            {
                InitializeComponent();
                // doTest();   //results in a recursive call!
                ///without the following instance will never be different than null, as GetInstance creates new Form on every call!
                instance = this;    
            }
            void doTest()
            {
                Form f1 = this;
                Form f2 = Form1.GetInstance();
                System.Diagnostics.Debug.WriteLine("f1=" + f2.GetType().FullName);
                System.Diagnostics.Debug.WriteLine("f2=" + f2.GetType().FullName);
            }
            private void button1_Click(object sender, EventArgs e)
            {
                doTest();   //does also not return the current form!
            }
        }
    }
