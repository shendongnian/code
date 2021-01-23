    public static bool AddNewCompany(Company company,List<Contacts> contact , Location local)
    {
        // get a configured DbCommand object
        DbCommand comm = GenericDataAccess.CreateCommand();
    
    
        //Set the store Proc name 
        comm.CommandText = "AddNewCompany";
    
    
        
        //create new parameter @CompanyName
        DbParameter param = comm.CreateParameter();
        param.ParameterName = "@CompanyName";
        param.Value = company.CompanyName;
        param.DbType = DbType.StringFixedLength;
        comm.Parameters.Add(param);
    
        //create new parameter @CompanyDetail 
        param = comm.CreateParameter();
        param.ParameterName = "@CompanyDetail";
        param.Value = company.CompanyDetail;
        param.DbType = DbType.StringFixedLength;
        comm.Parameters.Add(param);
    
        //create new parameter @ModifiedDate
        param = comm.CreateParameter();
        param.ParameterName = "@ModifiedDate";
        param.Value = DateTime.Now;
        param.DbType = DbType.DateTime;
        comm.Parameters.Add(param);
    
        //Company Info
        //create new parameter @Address
        param = comm.CreateParameter();
        param.ParameterName = "@Address";
        param.Value = local.Address;
        param.DbType = DbType.StringFixedLength;
        comm.Parameters.Add(param);
    
        //create new parameter @City
        param = comm.CreateParameter();
        param.ParameterName = "@City";
        param.Value = local.City;
        param.DbType = DbType.StringFixedLength;
        comm.Parameters.Add(param);
    
        //create new parameter @Province
        param = comm.CreateParameter();
        param.ParameterName = "@Province";
        param.Value = local.Province;
        param.DbType = DbType.StringFixedLength;
        comm.Parameters.Add(param);
    
        //create new parameter @PostalCode
        param = comm.CreateParameter();
        param.ParameterName = "@PostalCode";
        param.Value = local.PostalCode;
        param.DbType = DbType.StringFixedLength;
        comm.Parameters.Add(param);
    
        //create new parameter @Note
        param = comm.CreateParameter();
        param.ParameterName = "@Note";
        param.Value = local.Note;
        param.DbType = DbType.StringFixedLength;
        comm.Parameters.Add(param);
    
        //create new parameter @ModifiedDateLocation  
        param = comm.CreateParameter();
        param.ParameterName = "@ModifiedDateLocation";
        param.Value = DateTime.Now;
        param.DbType = DbType.StringFixedLength;
        comm.Parameters.Add(param);
    
        // need to split up the SP to add the company here 
        // execute company SP here
        // and get back the companyID
        // can just clear out the parameters and reuse it
        comm.Parameters.Clear();
        //and you can just define the parameters once
        //create new parameter @LabelContactTypeID
        paramTypeID = comm.CreateParameter();
        paramTypeID.ParameterName = "@LabelContactTypeID";       
        paramTypeID.DbType = DbType.StringFixedLength;
        comm.Parameters.Add(paramTypeID);
    
        //Company Info
        foreach (var c in contact)
        {
            //create new parameter @LabelContactTypeID
            paramTypeID.Value = c.LabelContactTypeID;
    
            //create new parameter @ContactDetails
            param = comm.CreateParameter();
            param.ParameterName = "@ContactDetails";
            param.Value = c.ContactDetail;
            param.DbType = DbType.StringFixedLength;
            comm.Parameters.Add(param);
    
            //create new parameter @Status
            param = comm.CreateParameter();
            param.ParameterName = "@Status";
            param.Value = c.Status;
            param.DbType = DbType.StringFixedLength;
            comm.Parameters.Add(param);
    
            //create new parameter @Notes
            param = comm.CreateParameter();
            param.ParameterName = "@Notes";
            param.Value = c.Notes;
            param.DbType = DbType.StringFixedLength;
            comm.Parameters.Add(param);
    
            try
            {
                 if (GenericDataAccess.ExecuteNonQuery(comm) == -1) return false;
                 // this syntax is not what I am used to
                 // i useally just comm.ExecuteNonQuer();
            }
            catch
            {
                return false;
            }
        }
        return true;    
    }
