    private void Filter(string text)     {      
       int outText;         
              if (Int32.TryParse(text, out outText))        
                      { 
                        // text was integer and parsed successfully.            
                        text = string.Empty;       
                       }     
     DataTable DT = new DataTable();  
               DT = PinCDAO.GetArea().AsEnumerable().Where(r => r.Field<int>("AreaID")== outText || (r.Field<string>("AreaDescription").Contains(text))).AsDataView().ToTable();  } 
