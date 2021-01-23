    if (!String.IsNullOrEmpty(selDate))
        
    {            
     CultureInfo myCItrad = new CultureInfo("bg-BG", false);
            
     DateTime parsedDate = DateTime.ParseExact(selDate, "yyyy-MM-dd" myCItrad);
            
     model = model.Where(m => m.Date == parsedDate);        
    }
