    using System;
    using System.Data;
    using System.Configuration;
    
    using System.Web;
    using System.Web.Security;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using System.Web.UI.WebControls.WebParts;
    
    using CrystalDecisions.Shared;
    using CrystalDecisions.CrystalReports.Engine;
    
    /// <summary>
    /// Summary description for CrystalReport
    /// </summary>
    'public class CrystalReport
    {
    
        private void SetDBLogOnInfo(ConnectionInfo connectionInfo, ReportDocument objectReportDocument, TableLogOnInfo tableLogonInfo)
        {
    
            Tables Tbl = objectReportDocument.Database.Tables;
    
            foreach (CrystalDecisions.CrystalReports.Engine.Table TmpTbl in Tbl)
            {
    
                tableLogonInfo = TmpTbl.LogOnInfo;
    
                tableLogonInfo.ConnectionInfo = connectionInfo;
    
                TmpTbl.ApplyLogOnInfo(tableLogonInfo);
            }
        }
    
        public ReportDocument CrystalLogon(String pReportPath, ConnectionInfo objConnInfo, ref TableLogOnInfo tableLogonInfo)
        {
    
            ReportDocument objReportDoc = new ReportDocument();
    
            objReportDoc.Load(pReportPath);
    
            SetDBLogOnInfo(objConnInfo, objReportDoc, tableLogonInfo);
    
            return objReportDoc;
    
        }
    
        public string[] GetCampaignConn()
        {
            //string server, database, userid, password;
            string strConn = System.Configuration.ConfigurationSettings.AppSettings["Connection String"];
            string[] strArray = strConn.Split(';');
    
            string[] strOutput = new string[4];
    
            for (int i = 0; i < strArray.Length; i++)
            {
                string[] strObject = strArray[i].Split('=');
    
                if (strObject[0] == "Data Source")
                {
                    strOutput[0] = strObject[1];
                }
                else if (strObject[0] == "Initial Catalog")
                {
                    strOutput[1] = strObject[1];
                }
                else if (strObject[0] == "User ID")
                {
                    strOutput[2] = strObject[1];
                }
                else if (strObject[0] == "Password")
                {
                    strOutput[3] = strObject[1];
                }
            }
    
            return strOutput;
        }
    }`
