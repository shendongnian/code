    public static bool checkBook(DataTable dt, String title)
    {
    try {
    
         foreach (DataRow dr in dt.Rows)
            {
                String checktitle = dr["Title"].ToString();
                if (title == checktitle)
                {
                    return true;
                }
                else
                    return false;
        
            }
            return false ;
        }
    catch (Exception ex)
    {
     //do something
    return false;
     }
    }
