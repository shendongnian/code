    StringBuilder sb = new StringBuilder();
        
    sb.Append(Name);
        
    if(!DateTime.TryParseExact(Date,"MM-dd-yyyy",new CultureInfo("en-US"),DateTimeStyles.None,out date))
        {
               Console.WriteLine("Invalid Choice");
    
        }
        else 
        {
            sb.Append(Date);
        }
