    public partial class Form1 : Form
    {
        private BackgroundWorker worker = null;
        private Rectangle rect = new Rectangle(0, 0, 100, 100);
        private Button button1 = new Button();
        private TextBox textBox1 = new TextBox();
    
        public Form1()
        {
            InitializeComponent();
    
            this.SuspendLayout();
    
            button1.Location = new System.Drawing.Point(260, 171);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(75, 23);
            button1.TabIndex = 0;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            button1.Click += new System.EventHandler(button1_Click);
    
            textBox1.Location = new System.Drawing.Point(282, 245);
            textBox1.Name = "textBox1";
            textBox1.Size = new System.Drawing.Size(100, 20);
            textBox1.TabIndex = 1;
    
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.button1);
    
            this.ResumeLayout();
    
            worker = new BackgroundWorker();
            worker.WorkerReportsProgress = true;
            worker.ProgressChanged += new ProgressChangedEventHandler(worker_ProgressChanged);
            worker.DoWork += new DoWorkEventHandler(worker_DoWork);
        }
    
        private void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < 100; i++)
            {
                rect.Y = i;
                System.Threading.Thread.Sleep(100);
                worker.ReportProgress(i);
            }
        }
    
        private void worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (this.InvokeRequired)
            {
                Invoke(new ProgressChangedEventHandler(worker_ProgressChanged), new object[] { sender, e });
                return;
            }
    
            this.Refresh();
        }
    
        private void button1_Click(object sender, EventArgs e)
        {
            worker.RunWorkerAsync();
        }
    
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
    
            e.Graphics.DrawRectangle(SystemPens.ActiveBorder, rect);
        }
    }
