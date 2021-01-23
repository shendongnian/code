                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    string text = dataGridView1.Rows[i].Cells["Name"].Value.ToString() + " " ;
                    bool added = false;
                    for (int j = 1; i < dataGridView1.Columns.Count; i++)
                    {
    
                        if (dataGridView1.Rows[i].Cells[j].Value.ToString() == "x")
                        {
                            text += dataGridView1.Columns[j].HeaderText.ToString() + ",";
                            if (!added)
                                added = true;
                        }
                    }
                    if(added)
                    {
                        text = text.Remove(text.Length - 1); //to remove ',' at the end
                    }
                    richTextBox1.Text += text + Environment.NewLine; //add to richTextbox1 with newline
                }
