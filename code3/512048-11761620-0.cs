    using System;
    using System.Collections.Generic;
    using System.Web.Services;
    using System.Data.SqlClient;
    using System.Configuration;
    using System.Data;
    
    
    [WebService]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.Web.Script.Services.ScriptService]
    public class AutoComplete : WebService
    {
        public AutoComplete()
        {
        }
    
    [WebMethod]
        public string[] GetCompletionList(string prefixText, int count)
        {
            if (count == 0)
            {
                count = 10;
            }
            DataTable dt = GetRecords(prefixText);
            List<string> items = new List<string>(count);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string strName = dt.Rows[i][0].ToString();
                items.Add(strName);
            }
            return items.ToArray();
        }
    
        public DataTable GetRecords(string strName)
        {
            string strConn = ConfigurationManager.ConnectionStrings["ProjectASPConnectionString"].ConnectionString;
            SqlConnection con = new SqlConnection(strConn);
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandType = System.Data.CommandType.Text;
            cmd.Parameters.AddWithValue("@issueno", strName); ///What name to place here
            cmd.CommandText = string.Format("Select distinct issueno as issueno from cet_sepcet where issueno like '{0}%'", strName); //what command to write here
            DataSet objDs = new DataSet();
            SqlDataAdapter dAdapter = new SqlDataAdapter();
            dAdapter.SelectCommand = cmd;
            con.Open();
            dAdapter.Fill(objDs);
            con.Close();
            return objDs.Tables[0];
        }
    }
