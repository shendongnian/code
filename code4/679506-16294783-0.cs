    private void btnSaveFilter_Click(object sender, EventArgs e)
    {
      foreach (ComboBox comboBox in panelFiltri.Controls)
      {  
         var itemCollection = comboBox.Items;
         int itemCount = itemCollection.Count; // which is 0 in your case
      }
    }
