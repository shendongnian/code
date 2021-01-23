    namespace WindowsFormsApplication1
    {
        public partial class Form1 : Form
        {
            public Form1()
            {
                InitializeComponent();
    
    
    
                this.Location = new System.Drawing.Point(100, 100);
                this.Name = "Form1";
                this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
                // to see if form is being centered, disable maximization
                //this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
                this.Load += new System.EventHandler(this.Form1_Load);
                this.ResumeLayout(false);
                this.PerformLayout();
    
            }
    
            private void Form1_Load(object sender, EventArgs e)
            {
                this.Text = "Convertor";
                this.MaximumSize = new System.Drawing.Size(620, 420); 
            }
        }
    }
