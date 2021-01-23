        private void cbSearch_TextUpdate(object sender, EventArgs e)
        {
            timer1.Stop();
            timer1.Dispose();
            timer1 = null;
            timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Interval = 1000;
            timer1.Start();
        }
        delegate void MethodDelegate(JObject result);
        void timer1_Tick(object sender, EventArgs e)
        {
            timer1.Stop();
            Debug.WriteLine(this.cbSearch.Text);
            Debug.WriteLine("Thread id: " + Thread.CurrentThread.ManagedThreadId);
            Dictionary<string, object> parameters = new Dictionary<string, object>();
            parameters["query"] = this.cbSearch.Text ?? "";
            this.session.rpc["advanced_search"].execAsync(parameters, results =>
            {
                this.BeginInvoke(new MethodDelegate(PopulateCombo), new object[] {results.GetResult()});
            });
        }
        public void PopulateCombo(JObject result)
        {
            Debug.WriteLine("Thread id: " + Thread.CurrentThread.ManagedThreadId);
            this.selectedPatientId = "";
            string text = cbSearch.Text;
            cbSearch.DroppedDown = false;
            cbSearch.Items.Clear();
            if (result.Value<bool>("success") == true)
            {
                JArray arr = result.Value<JArray>("data");
                for (int i = 0; i < arr.Count; i++)
                {
                    JToken item = arr[i];
                    cbSearch.Items.Add(new ComboBoxItem( item.Value<string>("name"), item.Value<string>("_id")));
                }
                try
                {
                    this.cbSearch.TextUpdate -= new System.EventHandler(this.cbSearch_TextUpdate);
                    cbSearch.DroppedDown = true; 
                    cbSearch.Text = text;
                    cbSearch.Select(cbSearch.Text.Length, 0);
                    
                }
                finally {
                    this.cbSearch.TextUpdate += new System.EventHandler(this.cbSearch_TextUpdate);
                }
            }
        }
