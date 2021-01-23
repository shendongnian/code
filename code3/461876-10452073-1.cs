        public static bool checkBook(DataTable dt, String title)
        {
          bool returnval= false;
          try 
          {
        
             foreach (DataRow dr in dt.Rows)
                {
                    String checktitle = dr["Title"].ToString();
                    if (title == checktitle)
                    {
                        returnval= true;
                    }
                    
            }
        catch (Exception ex)
        {
         //do something
        }
        return returnval;
       }
