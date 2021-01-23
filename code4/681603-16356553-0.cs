     public Form1()
            {
                InitializeComponent();
                listView1.View = View.Details;
                listView1.GridLines = false;
                listView1.Scrollable = true;
    
                listView1.FullRowSelect = true;
                listView1.Columns.Add("Track");
                listView1.Columns.Add("Status");
    
                Task t = new Task(new Action(() =>
                    {
                        RefreshLines();
                    }));
                t.Start();
            }
    
            public void RefreshLines()
            {
                if (this.InvokeRequired)
                {
                    this.Invoke(new MethodInvoker(this.RefreshLines));
                }
                for (int i = 1; i <= 10000; i++)
                {
                    ListViewItem LVI = new ListViewItem("Track " + i);
                    LVI.SubItems.Add("Updated");
                    listView1.Items.Add(LVI);
                    listView1.TopItem = LVI;
                    listView1.EnsureVisible(listView1.Items.Count - 1);
                    Application.DoEvents();
                }
            }
