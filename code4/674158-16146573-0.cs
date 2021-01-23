    int flag=0;
    try
    {
    
        if(ds.Tables["tablename"].Rows.Count>0)
        {
          // execute something
        }
    }
    catch(Exception ex)
    {
     flag=1;
    }
    
    if(flag==1)
    {
      messagebox.show("Table does not exists");
    }
