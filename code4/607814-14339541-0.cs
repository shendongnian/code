    //Get the data from your combo boxes. 
    public void GetValues()
    {
        string month = monthComboBox.SelectedValue.ToString(); 
        string year = yearComboBox.SelectedValue.ToString(); 
        InsertValuesInDatabase(month, year); 
    }
    //Insert the values into your table
    public void InsertValuesInDatabase(string month, string year)
    {
        try
        {
            using (var db = new MyEntities())
            {
                var newDateValueRecord = new DateValue() 
                                {
                                   Month = month, 
                                   Year = year
                                }
                db.DateValues.Add(newDateValueRecord); 
                db.SaveChanges(); 
            }
        }
        catch(Exception e)
        {
            Console.WriteLine(e); 
        }
      
    }
