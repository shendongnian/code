    foreach (DataRow dRNew in dtNew.Rows) 
    {
         DataRow row = null;
         try
         {
             row = dtOriginal.Find(dRNew["ID"]);
         }
         catch (MissingPrimaryKeyException)
         {
             row = dtOriginal.Select("ID=" + dRNew["ID"]).First();
         }
         if (row != null)
         {
             row["Column1"] = dRNew["Column1"]; 
             row["Column2"] = dRNew["Column2"]; 
             row["Column3"] = dRNew["Column3"]; 
         }
    } 
