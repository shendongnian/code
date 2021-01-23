    private void cbCheckbox_CheckedChanged(object sender, EventArgs e)
            {
                    if (cbCheckbox.Checked)  
                    {
                        testlist.Items.Clear();
                        testlist.Items.Add("Elemento1");
                        testlist.Items.Add("Elemento2");
                        testlist.Items.Add("Elemento3");
                        ltTestPool.DataSource = testlist;
                    }
    
                    else
                    {                  
                        testlist.Items.Clear();
                        ltTestPool.DataSource = testlist;
                    }
            }
