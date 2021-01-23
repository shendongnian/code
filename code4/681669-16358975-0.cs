    public static string GetFilePathFromConnectionString(string connectionString)
    {
        var attachDbFileName = new SqlConnectionStringBuilder(connectionString).AttachDBFilename;
        return attachDbFileName.Replace("|DataDirectory|", AppDomain.CurrentDomain.GetData("DataDirectory").ToString());
    }
