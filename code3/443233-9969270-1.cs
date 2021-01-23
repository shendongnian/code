    public partial class Form1 : Form
    {
        private System.Threading.Timer timer1;
        public Form1()
        {
            InitializeComponent();
            this.timer1 = new System.Threading.Timer(state => {
                var fileExists = System.IO.File.Exists(@"C:\file.txt");
                this.BeginInvoke(new Action(() => {
                    if (fileExists) {
                        label1.BackColor = System.Drawing.Color.Red;
                        //label2.BackColour..
                        //label3.BackColour..
                        //..                
                    }
                    else {
                        label1.BackColor = System.Drawing.Color.Gray;
                        //label2.BackColour..
                        //label3.BackColour..
                        //..                
                    }
                }));
            }, null, 0, 100);
        }
        private void button1_Click(object sender, EventArgs e)
        {
            
        }
    }
