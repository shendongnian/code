       private void btnSearch_Click(object sender, EventArgs e)
        {
            this.btnSearch.Enabled = false;
            this.Cursor = Cursors.WaitCursor;
            this.wfrm.Show();
            Thread t = new Thread(this.Search);
            t.Start();
        }
        private void Search()
        {
            while (isWorking)
            {
                DoHeavyWork();
                this.Invoke(new Action(ReportToWaitForm);
            }
            this.Invoke(new Action(() =>
                {
                    this.btnSearch.Enabled = true;
                    this.Cursor = Cursors.Default;
                    this.wfrm.Hide();
                }));
        }
