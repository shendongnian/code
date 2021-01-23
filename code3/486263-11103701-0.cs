    public List<object> get_All_Vehicles()
    {            
        var objv = new List<object>(); 
        IDataReader dr = null;
        var objdal = new csDAL();
        dr = objdal.executespreturndr("sp_Get_All_Distributor");
        while (dr.Read())
        {
            var d = new csDistributor();
            var v = new csVehicle();
            populate_Data(dr, d,v);
            objv.Add(v);                
            objv.Add(d);    
        }
        return objv;                        
    }
