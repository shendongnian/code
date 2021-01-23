    using System;
    using System.ComponentModel;
    using System.Windows.Forms;
    
    namespace MyLittleApp
    {
        public partial class MainWnd : Form
        {
           public static MainWnd Instance;
            public MainWnd()
            {
                Instance = this;
                InitializeComponent();
            }
    
            public void SayHello()
            {
                MessageBox.Show("Hello World!");
    
                // In reality, code that manipulates controls on the form
                // would go here. So this method cannot simply be made static.
            }
        }
    }
