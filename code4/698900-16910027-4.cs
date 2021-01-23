        // declare variables either globally or in the same method
        MatchCollection mcoll;
        Stopwatch s;
        int callbackCount = 0;
        List<Match> m1 = null;
        List<Match> m2 = null;
        private void btnHighlight_Click(object sender, EventArgs e)
        {
            //reset any exisiting formatting
            rtbMain.SelectAll();
            rtbMain.SelectionBackColor = Color.White;
            rtbMain.SelectionColor = Color.Black;
            rtbMain.DeselectAll();
            s = new Stopwatch();
            s.Start();
            Regex re = new Regex(@"(.)", RegexOptions.Compiled); // Notice COMPILED option
            mcoll = re.Matches(rtbMain.Text);
            // Break MatchCollection object into List<Matches> which is exactly half in size
            m1 = new List<Match>(mcoll.Count / 2);
            m2 = new List<Match>(mcoll.Count / 2);
            for (int k = 0; k < mcoll.Count; k++)
            {
                if (k < mcoll.Count / 2)
                    m1.Add(mcoll[k]);
                else
                    m2.Add(mcoll[k]);
            }
            Thread backgroundThread1 = new Thread(new ThreadStart(() => {
                match1(null, null);
            }));
            backgroundThread1.Start();
            Thread backgroundThread2 = new Thread(new ThreadStart(() =>
            {
                match2(null, null);
            }));
            backgroundThread2.Start();
        }
        public void match1(object obj, EventArgs e)
        {
            for (int i=0; i < m1.Count; i += 1)
            {
                if (rtbMain.InvokeRequired)
                {
                    EventHandler d = new EventHandler(match1);
                    rtbMain.Invoke(d);
                }
                else
                {
                    rtbMain.Select(m1[i].Index, m1[i].Length);
                    rtbMain.SelectionBackColor = Color.Black;
                    rtbMain.SelectionColor = Color.Red;
                }
            }
            stopTimer();
        }
        public void match2(object obj, EventArgs e)
        {
            for (int j=0; j < m2.Count; j += 1)
            {
                if (rtbMain.InvokeRequired)
                {
                    EventHandler d = new EventHandler(match2);
                    rtbMain.Invoke(d);
                }
                else
                {
                    rtbMain.Select(m2[j].Index, m2[j].Length);
                    rtbMain.SelectionBackColor = Color.Black;
                    rtbMain.SelectionColor = Color.Red;
                }
            }
            stopTimer();
        }
        void stopTimer()
        {
            callbackCount++;
            if (callbackCount == 2) // 2 because I am using two threads.
            {
                s.Stop();
                // Check Output Window
                Debug.Print("Evaluated in : " + s.Elapsed.Seconds.ToString());
            }
        }
