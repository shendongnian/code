    public List<Cab> GetCabType()
    {  
       List<Cab> CabTypeList = new List<Cab>();
       // to do : get your data in the data table. 
       foreach (DataRow row in table.Rows)
       {
         var cab= new Cab();
         cab.CabType =  row["CabType"].ToString();
         cab.CabId = Convert.ToInt32(row["Cab_Id"]);
         CabTypeList.Add(cab);
       }
       return CabTypeList;
    }
