    string value = myTextBox.Text;
    int myNumber = 0;
    
    if(!string.IsNullOrEmpty(value))
    {
        int.TryParse(value, out myNumber);
        if(myNumber > 0)
        {
             // do stuff
        }
    }
