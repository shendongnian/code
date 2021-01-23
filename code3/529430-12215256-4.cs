    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Data;
    using System.Data.SqlClient;
    using System.Collections;
    
    public class DAL : IDisposable
    {
        SqlConnection con;
    
        public DAL()
        {
            con = new SqlConnection("Connection String");
        }
    
        public int Insert(string CMD, Hashtable objHash)
        {
            int val = 0;
            try
            {
                SqlCommand cmd1 = new SqlCommand(CMD, con);
                cmd1.CommandType = CommandType.StoredProcedure;
                foreach (DictionaryEntry de in objHash)
                {
                    cmd1.Parameters.AddWithValue(Convert.ToString(de.Key), Convert.ToString(de.Value));
                }
                con.Open();
                val = cmd1.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
            }
            return val;
        }
    
        #region IDisposable Members
    
        public void Dispose()
        {
            throw new NotImplementedException();
        }
    
        #endregion
    }
