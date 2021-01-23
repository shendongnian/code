    private static string ReadConnectionstringFromFile(string path)
    {
        try
        {
            using (var sr = new StreamReader(File.Open(path, FileMode.Open))
            {
                var cb = new SqlConnectionStringBuilder();
                cb.DataSource = sr.ReadLine();
                cb.InitialCatalog = sr.ReadLine();
                cb.UserID = sr.ReadLine();
                cb.Password = sr.ReadLine();
                return cb.ToString();
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show(ex.ToString(), ex.message);
            throw new CustomExceptionClassForYourApplication("Trying to get connection string from "
                + path, ex);
        }
    }
