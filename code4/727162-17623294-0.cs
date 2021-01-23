    StringBuilder csv = new StringBuilder();
    myList.ForEach(c=>{
       csv.Append(c.ID).Append(",");
       csv.Append(c.Name).Append(System.Environment.NewLine); 
    });
