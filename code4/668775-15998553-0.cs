        private void button1_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "";
            label1.Text = "Milliseconds: ";
            var watch = Stopwatch.StartNew();
            List<Task> tasks = new List<Task>();
            for (int i = 2; i < 20; i++)
            {
                int j = i;
                var t = Task.Factory.StartNew(() =>
                {
                    var result = SumRootN(j);
                    richTextBox1.Invoke(new Action(
                            () =>
                            richTextBox1.Text += "root " + j.ToString() + " " + result.ToString() + Environment.NewLine));
                });
                tasks.Add(t);
            }
            Task.Factory.ContinueWhenAll(tasks.ToArray(),
                  result =>
                  {
                      var time = watch.ElapsedMilliseconds;
                      label1.Invoke(new Action(() => label1.Text += time.ToString()));
                  });
        }
