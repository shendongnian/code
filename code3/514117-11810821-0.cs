    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
                // Sign up for the FlowLayoutPanel Layout event.
                // When that event occurs, run your layout logic
                // using BeginInvoke to give the control a chance
                // to "settle down".
                //
    
                this.flowLayoutPanel1.Layout += delegate { this.BeginInvoke( ( Action )this.DoYourWorkHere ); };
            }
    
            void DoYourWorkHere()
            {
                //TODO: do your custom layout logic here.
            }
        }
    }
