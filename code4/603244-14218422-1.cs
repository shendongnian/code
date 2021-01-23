       public Form1()
        {
            InitializeComponent();
            hooks.HookAll(this);
            // or something like: hooks.Hook(this, "Load");
            hooks.Hook(button1, "Click");
            
        }
        private EventHooks hooks = new EventHooks();
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = 
                string.Format("Load: {0}\r\nClick: {1}\r\nButton click: {2}\r\n",
                hooks.IsCalled(this, "Load"),
                hooks.IsCalled(this, "Click"),
                hooks.IsCalled(button1, "Click"));
        }
