    public static string tryConn(string address, string name, string password)
    {
            string connString = (address + ':' + name + ';' + password);
            try
            {
                connect(connString);
                return true;
            }
            catch
            {
                return false;
            }
    }
