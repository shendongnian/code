        DialogResult dialog = new DialogResult();
        dialog = MessageBox.Show("Do you want to close?", "Alert!", MessageBoxButtons.YesNo);
        if (dialog == DialogResult.Yes)
        {
            System.Environment.Exit(1);
        }
      
