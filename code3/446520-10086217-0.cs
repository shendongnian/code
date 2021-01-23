    private void btnsend_Click(object sender, EventArgs e)
        {
            foreach (Control c in Controls)
            {
                c.Enabled = false;
            }
            if (!bgw.IsBusy)
            {
                bgw.RunWorkerAsync();
            }
        }
        private void bgw_DoWork(object sender, DoWorkEventArgs e)
        {
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if ((bgw.CancellationPending == true))
                {
                    e.Cancel = true;
                    break;
                }
                else
                {
                    Invoke((MethodInvoker)delegate()
                    {
                        using (var sp = new SerialPort(cbcomport.Text))
                        {
                            try
                            {
                                sp.Open();
                                sp.WriteLine("AT" + Environment.NewLine);
                                sp.WriteLine("AT+CMGF=1" + Environment.NewLine);
                                sp.WriteLine("AT+CMGS=\"" + dt.Rows[i]["PhoneNo"] + "\"" + Environment.NewLine);
                                sp.WriteLine(tbsms.Text + (char)26);
                                if (sp.BytesToRead > 0)
                                {
                                    tbsentto.Text = i + 1 + " of " + dt.Rows.Count;
                                }
                                Thread.Sleep(5000);
                            }
                            catch (Exception ex)
                            {
                                if (MessageBox.Show(ex.Message, "Error", MessageBoxButtons.RetryCancel, MessageBoxIcon.Error) == System.Windows.Forms.DialogResult.Retry)
                                {
                                    try
                                    {
                                        sp.Open();
                                        sp.WriteLine("AT" + Environment.NewLine);
                                        sp.WriteLine("AT+CMGF=1" + Environment.NewLine);
                                        sp.WriteLine("AT+CMGS=\"" + dt.Rows[i]["PhoneNo"] + "\"" + Environment.NewLine);
                                        sp.WriteLine(tbsms.Text + (char)26);
                                        if (sp.BytesToRead > 0)
                                        {
                                            tbsentto.Text = i + 1 + " of " + dt.Rows.Count;
                                        }
                                        Thread.Sleep(5000);
                                    }
                                    catch (Exception ex2)
                                    {
                                        MessageBox.Show(ex2.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                        bgw.CancelAsync();
                                        
                                    }
                                }
                                else
                                {
                                    bgw.CancelAsync();
                                }
                            }
                        }
                    });
                }
            }
        }
        private void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            foreach (Control c in Controls)
            {
                c.Enabled = true;
            }
        }
