        string strConnection = System.Configuration.ConfigurationManager.ConnectionStrings["MHMRA_TexMedEvsConnectionString"].ConnectionString.ToString();
        String excelConnString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0\"", filePath);
        //Create Connection to Excel work book 
        using (OleDbConnection excelConnection = new OleDbConnection(excelConnString))
        {
            //Create OleDbCommand to fetch data from Excel 
            using (OleDbCommand cmd = new OleDbCommand("Select * from [Crosswalk$]", excelConnection))
            {
                excelConnection.Open();
                using (OleDbDataReader dReader = cmd.ExecuteReader())
                {
                    using (SqlBulkCopy sqlBulk = new SqlBulkCopy(strConnection))
                    {
                        //Give your Destination table name 
                        sqlBulk.DestinationTableName = "PaySrcCrosswalk";
                        SqlBulkCopyColumnMapping AdmissionPaySrcID=new SqlBulkCopyColumnMapping("AdmissionPaySrcID","AdmissionPaySrcID");
                        sqlBulk.ColumnMappings.Add(AdmissionPaySrcID);
                        SqlBulkCopyColumnMapping TMHP_Detail = new SqlBulkCopyColumnMapping("TMHP_Detail", "TMHP_Detail");
                        sqlBulk.ColumnMappings.Add(TMHP_Detail);
                        SqlBulkCopyColumnMapping PaySrcType = new SqlBulkCopyColumnMapping("PaySrcType", "PaySrcType");
                        sqlBulk.ColumnMappings.Add(PaySrcType);
                        SqlBulkCopyColumnMapping AgencyID = new SqlBulkCopyColumnMapping("AgencyID", "AgencyID");
                        sqlBulk.ColumnMappings.Add(AgencyID);
                        SqlBulkCopyColumnMapping CountyCode = new SqlBulkCopyColumnMapping("CountyCode", "CountyCode");
                        sqlBulk.ColumnMappings.Add(CountyCode);
                        SqlBulkCopyColumnMapping EntityID = new SqlBulkCopyColumnMapping("EntityID", "EntityID");
                        sqlBulk.ColumnMappings.Add(EntityID);
                       
                        sqlBulk.WriteToServer(dReader);
                    }
                }
            }
        }
    }  
