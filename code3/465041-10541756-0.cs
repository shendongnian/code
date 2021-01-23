        public delegate void DelLabelText(Label l, string s);
        public DelLabelText delLabelText;
        public Form1()
        {
            InitializeComponent();
            delLabelText = Label_Text;
            // Initialize text
            lblOpenStatus.Text = "Closed";
            // Create and start thread
            Thread threadUpdateLabel = new Thread(UpdateLabel_Threaded);
            threadUpdateLabel.Start();
        }
        // Thread function that constantly checks if the text is correct
        public void UpdateLabel_Threaded()
        {
            while (true)
            {
                // 24 hour clock so 17 means 5
                if ((DateTime.Now.Hour >= 10 && DateTime.Now.Hour < 17) || (DateTime.Now.Hour == 17 && DateTime.Now.Minute == 0 && DateTime.Now.Second == 0))
                {
                    if (lblOpenStatus.Text.ToLower() == "closed")
                    {
                        Label_Text(lblOpenStatus, "Open");
                    }
                }
                else
                {
                    if (lblOpenStatus.Text.ToLower() == "open")
                    {
                        Label_Text(lblOpenStatus, "Closed");
                    }
                }
            }
        }
        // Set the text using invoke, because text is changed outside of main thread
        public void Label_Text(Label label, string text)
        {
            if (label.InvokeRequired)
            {
                label.Invoke(delLabelText, new object[] { label, text });
            }
            else
            {
                label.Text = text;
            }
        }
