    protected void CBCountries_SelectedIndexChanged(object sender, EventArgs e)
    {
        string result = Request.Form["__EVENTTARGET"];
        string[] checkedBox = result.Split('$');
        int index = int.Parse(checkedBox[checkedBox.Length - 1]);
    
        if (CBCountries.Items[index].Selected)
        {
            String Country = CBCountries.Items[index].Value;
            //query your cities table based on selected Country
            BindCities(Country);     
        }
        else
        {
        }
    }
