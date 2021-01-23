    private void buttonWijzig_Click(object sender, EventArgs e)
    {
         Button knop = sender as Button;
         int id = 0, maximumBedrag = 0;
    
         // The ID could be extracted from the control name starting at 4th position
         id = Convert.ToInt32(knop.Name.Substring(4));
         // The ID is the key to find the corresponding NUmericUpDown in the dictionary
         NumericUpDown numeriekvak = NumeriekVakken[id];
         // update limit
         DBManager.LimietRow limiet = new DBManager.LimietDataTable().NewLimietRow();
         maximumBedrag = Convert.ToInt32(numeriekvak.Value);
         blLimiet.updateLimiet(id, maximumBedrag);
    
         // The control name is already available, no need to use the list to retrieve it
         labelBevestigingLimiet.Text = "Limiet " + numeriekVak.Name + " is succesvol gewijzigd naar " + maximumBedrag + "€";
    
    }
