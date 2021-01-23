    public bool CreatePatient()
    {
        IDbConnection connection = database.CreateOpenConnection();
        IDbTransaction transaction = database.BeginTransaction(connection);
    
        try
        {
        GenerateRegNo();
        SQL_STATEMENT = "INSERT INTO TblPatientRegistration(RegistrationNo, HospitalID, NIC, AdmitDate, BHTNo, WardNo) 
                         VALUES(@RegNo, @HospiatlNo, @NIC, @Admitdate, @BHTNo, @WardNo)";
        IDbCommand com = database.CreateCommandTransaction(SQL_STATEMENT, connection, transaction);
        com.Parameters.Add(database.CreateParameter("@RegNo", PatientRegistration.RegistrationNo));
        com.Parameters.Add(database.CreateParameter("@HospiatlNo", PatientRegistration.HospitalID));
        com.Parameters.Add(database.CreateParameter("@NIC", PatientRegistration.NIC));
            String admitDate = txtAdmitDate.Text;
            DateTime parsedAdmitDate;
            if (DateTime.TryParseExact(admitDate, "d/M/y", CultureInfo.InvariantCulture, DateTimeStyles.None, out parsedAdmitDate))
                PatientRegistration.AdmitDate = parsedAdmitDate;
        //com.Parameters.Add(database.CreateParameter("@Admitdate", PatientRegistration.AdmitDate));
        com.Parameters.Add(database.CreateParameter("@BHTNo", PatientRegistration.BHTNo));
        com.Parameters.Add(database.CreateParameter("@WardNo", PatientRegistration.WardNo));
        if (com.ExecuteNonQuery() > 0)
        {
            string updStatement = "Update TblControl set RegNo=RegNo+1";
            IDbCommand com2 = database.CreateCommandTransaction(updStatement, connection, transaction);
            com2.ExecuteNonQuery();
            transaction.Commit();
        return true;
        }
        else
        {
            transaction.Rollback();
            return false;
        }
     }
     catch (Exception)
     {
        transaction.Rollback();
        return false;
     }
    }
