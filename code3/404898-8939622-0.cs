                        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
                    {
                        if (this.InvokeRequired)
                        {
                            this.Invoke(bgw_RunWorkerCompleted, sender, e);
                            return;
                        }
                        dgUsers.Rows[0].Cells[0].Value = e.Result; 
                    }
