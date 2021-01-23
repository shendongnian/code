    void dataGridView1_EditingControlShowing(object sender, DataGridViewEditingControlShowingEventArgs e)
                {
                    if (e.Control is Button)
                    {
                        Button btn = e.Control as Button;
    
                        // hook or unhook click event here
                    }
                }
