    private DelayUpdate delayUpdate;
    
            public Form1()
            {
                InitializeComponent();
    
                this.delayUpdate = new DelayUpdate()
                {
                    interval = 500,
                    updatesPerPush = 1,
                };
                this.delayUpdate.PushUpdate += this.DelayUpdate_PushUpdate;
    
                this.search_textBox.TextChanged += this.Search_textBox_TextChanged;
            }
    
            private void DelayUpdate_PushUpdate(object sender, EventArgs e)
            {
                throw new NotImplementedException();
            }
