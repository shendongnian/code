        private void button1_Click(object sender, EventArgs e)
        {
            Thread workerThread = new Thread(ExpensiveMethod);
            btnShow.Visible = false;
            workerThread.Start();
        }
        private void ExpensiveMethod()
        {
            for (int i = 0; i < int.MaxValue; i++)
            {
                
            }
            btnShow.Visible = true;
        }
