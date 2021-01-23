            if (dataGridView1.ColumnCount - 1 == e.ColumnIndex)  //if last column
            {
                KeyEventArgs forKeyDown = new KeyEventArgs(Keys.Enter);
                notlastColumn = false;
                dataGridView1_KeyDown(dataGridView1, forKeyDown);
                
            }
            else
            {
                SendKeys.Send("{up}");
                SendKeys.Send("{right}");
            }
        }
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && notlastColumn) //if not last column move to nex
            {
                SendKeys.Send("{up}");
                SendKeys.Send("{right}");
            }
            else if (e.KeyCode == Keys.Enter)
            {
                SendKeys.Send("{home}");//go to first column
                notlastColumn = true;
            }
            
        }
