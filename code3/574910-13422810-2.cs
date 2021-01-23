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
    //add only one contact
        /create new parameter @LabelContactTypeID
            param = comm.CreateParameter();
            param.ParameterName = "@LabelContactTypeID";
            param.Value = contact[0].LabelContactTypeID;
            param.DbType = DbType.StringFixedLength;
            comm.Parameters.Add(param);
        //create new parameter @ContactDetails
        param = comm.CreateParameter();
        param.ParameterName = "@ContactDetails";
        param.Value = contact[0].ContactDetail;
        param.DbType = DbType.StringFixedLength;
        comm.Parameters.Add(param);
        //create new parameter @Status
        param = comm.CreateParameter();
        param.ParameterName = "@Status";
        param.Value = contact[0].Status;
        param.DbType = DbType.StringFixedLength;
        comm.Parameters.Add(param);
        //create new parameter @Notes
        param = comm.CreateParameter();
        param.ParameterName = "@Notes";
        param.Value = contact[0].Notes;
        param.DbType = DbType.StringFixedLength;
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
    try
    {
        return (GenericDataAccess.ExecuteNonQuery(comm) != -1);
    }
    catch
    {
        return false;
    }
