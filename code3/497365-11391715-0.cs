    public string this[string columnName]
    {
        //The validation logic goes here
        if( columnName == "Property1")
        {
            //put validation here and return error message if exists
            if(this.Property1 == "")
            {
                 return "The field Property1 is required";
            }
        }
        //and so on
    }
    public string Error
    {
        return "This object is not valid";
    }
