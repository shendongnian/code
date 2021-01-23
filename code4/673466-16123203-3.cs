    using System;
    using System.Windows.Forms;
    
    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                var foo = new ExPanel();
                
                Controls.Add(foo);
                foo.image =  System.Drawing.Image.FromFile(@"C:\foo.jpg");
                foo.Refresh();
            }
        }
    }
