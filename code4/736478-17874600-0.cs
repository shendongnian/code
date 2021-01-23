     private void TreeView1_AfterSelect(object sender, TeeeViewEventArgs e)
     {
        if (e.node == nodePanel11)
        {
           Panel11.Visible = true;   // This presumes that the panel already exists 
                                     // and is invisible
           Panel12.Visible = false;
        }
        else if (e.node == nodePanel12)
        {
            Panel12.Visible = true;
            Panel11.Visible = false;
        }
     }
