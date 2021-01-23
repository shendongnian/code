      [WebMethod]
        public static Details[] GetData()
        {
            DataSet dsDetails = new DataSet();
            List<Details> details = new List<Details>();
            try
            {
                Database db = DatabaseFactory.CreateDatabase("String");
                DbCommand dbCommand = db.GetStoredProcCommand("GetDetails");
                
                dsDetails = (DataSet)db.ExecuteDataSet(dbCommand);
                foreach (DataRow dtrow in dsDetails.Tables[0].Rows)
                {
                    Details report = new Details();
                    report.ID = Convert.ToInt32(dtrow["ID"].ToString());
                    report.ReferenceID = Convert.ToInt32(dtrow["ReferenceID"].ToString());
                    report.ProductID = dtrow["Name"].ToString();
                    
                    details.Add(report);
                }
            }
            catch (Exception)
            {
            }
            finally
            {
            }
            return details.ToArray();
        }
