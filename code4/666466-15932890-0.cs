    private void button1_Click(object sender, EventArgs e)
        {
            this.panel1.Visible = false;
            this.panel2.Visible = true;
            new Thread(ProgressBAR).Start();
        }
        private void ProgressBAR()
        {
            Thread.Sleep(5);
            for (int start = 0; start <= 100; start++)
            {
                  this.Invoke(new Action(() => this.progressBar1.Value = start));
                Thread.Sleep(5);
            }
        }
