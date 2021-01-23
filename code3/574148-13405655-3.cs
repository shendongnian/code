    private void button1_Click(object sender, EventArgs e)
            {
                if (!bgw.IsBusy)
                {
                    OpenFileDialog openFileDialog1 = new OpenFileDialog();
                    openFileDialog1.Filter = "Text Files|*.txt";
                    openFileDialog1.Title = "Select a Text file";
                    openFileDialog1.FileName = "";
                    DialogResult result = openFileDialog1.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        string file = openFileDialog1.FileName;
                        listView1.BeginUpdate();
                        bgw.RunWorkerAsync(file);
                    }
                }
                else
                    MessageBox.Show("File reading at the moment, try later!");
            }
    
           
            void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
            {
                listView1.EndUpdate();
            }
            void bgw_DoWork(object sender, DoWorkEventArgs e)
            {
                string fileName = (string)e.Argument;
                TextReader t = new StreamReader(fileName);
                string line = string.Empty;
                while ((line = t.ReadLine()) != null)
                {
                    string nLine = line;
                    this.Invoke((MethodInvoker)delegate { listBox1.Items.Add(nLine); });
                }
            }
