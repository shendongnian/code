    public partial class Form1 : Form
    {
        Button button1 = new System.Windows.Forms.Button();
    
        public Form1()
        {
            InitializeComponent();
    
            SuspendLayout();
            button1.Location = new System.Drawing.Point(0, 0);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(104, 28);
            button1.TabIndex = 1;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += new System.EventHandler(this.button1_Click);
            Controls.Add(this.button1);
            ResumeLayout(false);
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                button1.Top = i;
                System.Threading.Thread.Sleep(100);
            }
        }
    }
