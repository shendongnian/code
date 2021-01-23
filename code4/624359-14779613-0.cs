    using(var context = new MyDataContext())
    {
        using(var cmd = context.Database.Connection.CreateCommand())
        {
            cmd.CommandText = "cpas_POIDVendorProjectDate";
            cmd.CommandType = CommandType.StoredProcedure;
            //if the stored proc accepts params, here is where you pass them in
            cmd.Parameters.Add(new SqlParameter("VendorId", 10));
            cmd.Parameters.Add(new SqlParameter("ProjectId", 12));
            cmd.Parameters.Add(new SqlParameter("WorkDate", DateTimw.Now));
            var poid = (int)cmd.ExecuteScalar();
        }
    }
