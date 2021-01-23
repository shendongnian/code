    public DataSet GetCollegeSerachData(int PageNum,int PageSize,out int TotalRecords)
            {
                DS = new DataSet();
                ObjDataWrapper = new DataWrapper(ClsCommon.CnnString, CommandType.StoredProcedure);
                TotalRecords=0;
                ErrorCount = 0;
                Searchpattern = "";
                try
                {
                   
    
                    ObjDataWrapper.AddParameter("@PageNum", PageNum);
                    ObjDataWrapper.AddParameter("@PageSize", PageSize);
                    
                    SqlParameter ObjTotalRecords=(SqlParameter)(ObjDataWrapper.AddParameter("@TotalRowsNum","",SqlDbType.Int,ParameterDirection.Output));
                  
    
                   
                    DS=ObjDataWrapper.ExecuteDataSet("ADMJGetCollegeSearch");
                   if(ObjTotalRecords.Value!= DBNull.Value || ObjTotalRecords!=null)
                   {
                       TotalRecords=Convert.ToInt32(ObjTotalRecords.Value);
                   }
                   
                }
                catch (Exception Ex)
                {
                    string err = Ex.Message;
                    if (Ex.InnerException != null)
                    {
                        err = err + " :: Inner Exception :- " + Ex.InnerException.Message;
                    }
                    string addInfo = "Error While Executing GetCollegeSerachData in ClsColleges:: -> ";
                    ClsExceptionPublisher objPub = new ClsExceptionPublisher();
                    objPub.Publish(err, addInfo);
                }
                return DS;
            }
