    public bool IsExist(string name, string pass)
        {
            string sql = "select * from Users where UName='" + name + "' and Pass='" + pass + "'"; ; 
            DataSet ds = General.GetData(sql); // General class has function called GetData which obviouslly gets the data of the required SQL information.
            if (ds.Tables[0].Rows.Count > 0)
                return true;
            return false;
        }
