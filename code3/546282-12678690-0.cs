    public bool AllowConnection = false;
    private void simpleButton1_Click(object sender, EventArgs e)
    {
         foreach (var row in myClass.ds.Tables["Users"].AsEnumerable())
         {
             if (row[1].ToString().ToLower() == idBox.Text.ToLower() && row[2].ToString().ToLower() == mdpBox.Text.ToLower())
                AllowConnection = true;
         }
    
         if (!AllowConnection)
             XtraMessageBox.Show("Invalide Information", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
    }
