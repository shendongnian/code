    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using DevExpress.XtraSplashScreen;
    using System.Threading;
    namespace WaitForm_SetDescription {
        public partial class Form1 : Form {
            public Form1() {
                InitializeComponent();
            }
            private void btnShowWaitForm_Click(object sender, EventArgs e) {
                //Open MyWaitForm!!!
                SplashScreenManager.ShowForm(this, typeof(MyWaitForm), true, true, false);
                //The Wait Form is opened in a separate thread. To change its Description, use the SetWaitFormDescription method.
                for (int i = 1; i <= 100; i++) {
                    SplashScreenManager.Default.SetWaitFormDescription(i.ToString() + "%");
                    Thread.Sleep(25);
                }
                //Close Wait Form
                SplashScreenManager.CloseForm(false);
            }
        }
    }
