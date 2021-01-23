    Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            this.SuspendLayout();
            for (int i = 0; i < 2000; i++)
            {
                var textbox = new TextBox();
                //textbox.SuspendLayout();
                //textbox.Dock = i% 2 ==0 ? DockStyle.Left : DockStyle.Right;
                textbox.Dock = DockStyle.Fill;
                textbox.Top = i * 10;
                textbox.Text = i.ToString();
                this.Controls.Add(textbox);
                //textbox.ResumeLayout(false);
               
            }
            stopWatch.Stop();
            TimeSpan ts = stopWatch.Elapsed;
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}",ts.Hours, ts.Minutes, ts.Seconds,ts.Milliseconds / 10);
            this.ResumeLayout(true);
            MessageBox.Show(elapsedTime);
