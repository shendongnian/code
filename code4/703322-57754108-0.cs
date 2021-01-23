        SMS API CLASS::
        
        #region Namespaces
        using System;
        using System.Collections.Generic;
        using System.Linq;
        using System.Web;
        using System.Data;
        using System.Data.SqlClient;
        using System.Data.Sql;
        using System.Data.SqlTypes;
        using System.Configuration;
        using System.Net;
        using System.IO;
        using SendBirthdaySMS;
        #endregion
        
        /// <summary>
        /// Summary description for SMSAPI
        /// </summary>
        public class SMSAPI
        {
        
            MyConnection con = new MyConnection();
            public DataSet ds = new DataSet();
            public SqlDataAdapter da = new SqlDataAdapter();
        	public SMSAPI()
        	{
        		//
        		// TODO: Add constructor logic here
        		//
        	}
        
        
            /*Get The SMS API*/
            public string GETSMSAPI()
            {
        
                con.Open();
                string QuerySMS, StringSMS, APISMS, UserName, Password, Sender, Priority;
                QuerySMS = "SP_SMSAPIMaster_GetDetail";
                StringSMS = APISMS = UserName = Password = Sender = Priority = "";
                con.cmd.CommandText = QuerySMS;
                try
                {
                    con.Open();
                    con.cmd.ExecuteNonQuery();
                    SqlDataAdapter da = new SqlDataAdapter(con.cmd);
                    da.Fill(ds, "tbl_SMSAPIMaster");
        
                    if (ds.Tables["tbl_SMSAPIMaster"].Rows.Count > 0)
                    {
                        APISMS = ds.Tables["tbl_SMSAPIMaster"].Rows[0]["SMSAPI"].ToString();
                        UserName = ds.Tables["tbl_SMSAPIMaster"].Rows[0]["UserName"].ToString();
                        Password = ds.Tables["tbl_SMSAPIMaster"].Rows[0]["Password"].ToString();
                        Sender = ds.Tables["tbl_SMSAPIMaster"].Rows[0]["Sender"].ToString();
                        Priority = ds.Tables["tbl_SMSAPIMaster"].Rows[0]["Priority"].ToString();
                        StringSMS = APISMS.Replace("uid", UserName).Replace("psd", Password).Replace("sndid", Sender).Replace("prt", Priority);
                    }
                    else
                    {
                        StringSMS = "";
                    }
                }
                catch
                {
                }
                finally
                {
                    con.Close();
                }
                
                return StringSMS;
        
            }
            /*Call The SMS API*/
            public string GetAPICALL(string url)
            {
                HttpWebRequest httpreq = (HttpWebRequest)WebRequest.Create(url);
                try
                {
                    HttpWebResponse httpres = (HttpWebResponse)httpreq.GetResponse();
                    StreamReader sr = new StreamReader(httpres.GetResponseStream());
                    string results = sr.ReadToEnd();
                    sr.Close();
                    return results;
                }
                catch
                {
                    return "0";
                }
            }
            
        }
    
    
    
     private void SendBirthdaySMS(string lbl_MobileNo)
            {
                #region For Employee Message Content..!!
                string Msgs, SMSString;
                Msgs = SMSString = "";
                SMSString = SMSAPI.GETSMSAPI();
                Msgs = "Hello";
                lblMessageContent.Text = Msgs;
                SMSString = SMSString.Replace("num", lbl_MobileNo).Replace("fedmesge", Msgs);
                string Result = SMSAPI.GetAPICALL(SMSString);
                #endregion
    
                
            }
