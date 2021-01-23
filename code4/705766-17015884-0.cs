    private void Button1_Click(object sender, EventArgs e)
    {
         lstOutput.Items.Clear();//lstOutput is the listbox
         int inches = Convert.ToInt32(txtInches.Text);
         string UnitOfMeasure = txtUnitOfMeasure.Text.ToUpper();
         ConvertToYardsOrFeet(inches, UnitOfMeasure);
    }
    
    private void ConvertToYardsOrFeet(int inches, string UnitOfMeasure)
        {
            int Yard = 0;
            int Feet = 0;
            int Inches = 0;
    
            if (UnitOfMeasure == "Y")
            {
                 Yard = inches / 36;
                 Feet = inches % 36 / 12;
                 Inches = inches % 12;
    
                 lstOutput.Items.Add(Yard + " Yards" + Feet + " Feet" + Inches + " Inches.");
              
            }
    
            if (UnitOfMeasure == "F")
            {
                Feet = inches / 12;
                Inches = inches % 12;
    
                lstOutput.Items.Add(Feet + " Feet" + Inches + " Inches.");
            }
        }
