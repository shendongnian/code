     this.richTextBox1.AllowDrop = true; this.richTextBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.textBox1_DragDrop); this.richTextBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.textBox1_DragEnter);
    private void textBox1_DragDrop(object sender, DragEventArgs e)
                {
                    try
                    {
                        Array a = (Array)e.Data.GetData(DataFormats.FileDrop);
                        if (a != null)
                        {
                            string s = a.GetValue(0).ToString();
                            this.Activate();
                            OpenFile(s);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error in DragDrop function: " + ex.Message);
                    }
                  
                }
        
                private void OpenFile(string sFile)
                {
                    try
                    {
                        StreamReader StreamReader1 = new StreamReader(sFile);
                        richTextBox1.Text = StreamReader1.ReadToEnd();
                        StreamReader1.Close();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(this, ex.Message, "Error loading from file");
                    }
        
                }
        
                private void textBox1_DragEnter(object sender, DragEventArgs e)
                {
                    if (e.Data.GetDataPresent(DataFormats.FileDrop))
                        e.Effect = DragDropEffects.Copy;
                    else
                        e.Effect = DragDropEffects.None;
                  
                }
