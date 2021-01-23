    private void ToonCategorien()
        {
            cboCategorie.Items.Clear();
            foreach (String sCategorie in marrCategorie){
                if (!cboCategorie.Items.Contains(sCategorie))
                {                
                    cboCategorie.Items.Add(sCategorie);
                }
            }
        }
