    private void cbCheckbox_CheckedChanged(object sender, EventArgs e)
                {
                        if (cbCheckbox.Checked)  
                        {   
                            testlist.Clear();
                            ltTestPool.DataSource = null;
                            testlist.Add("Elemento1");
                            testlist.Add("Elemento2");
                            testlist.Add("Elemento3");
                            ltTestPool.DataSource = testlist;
                        }
        
                        else
                        {   testlist.Clear();  
                            ltTestPool.DataSource =null;            
                            testlist.Add("Elemento1");
                            testlist.Add("Elemento2");
                            testlist.Add("Elemento3");
                            ltTestPool.DataSource = testlist;
                        }
            
    }
