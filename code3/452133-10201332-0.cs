    private void btnAddApartment_Click(object sender, EventArgs e)
    {
    //instantiate appartment and add it to arraylist
    try
    {
        Apartment anApartment = new Apartment(txtID.Text, txtAddress.Text, int.Parse(txtYearBuilt.Text), int.Parse(txtBedrooms.Text),
            double.Parse(txtSquareFootage.Text), double.Parse(txtPrice.Text), txtFurnished.Text);
        Home.Add(anApartment);
        AddApartmentToListBox();
        ClearText(this);
    }
    catch (Exception)
    {
        MessageBox.Show("Make sure you entered everything correctly!", "Error", MessageBoxButtons.OK);
    }            
