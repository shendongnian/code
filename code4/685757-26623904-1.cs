    string strRetrun = string.Empty;
     using (OracleConnection objCon = (OracleConnection)_connection)
            {
                using (OracleCommand objCom = new OracleCommand())
                {
                    objCom.Connection = objCon;
                    objCom.CommandText = "SAM.PKG_SAM_ECH.F_FUND_TRANSFER_TYPE";
                    objCom.CommandType = CommandType.StoredProcedure;
    
                    OracleParameter codeReturn = new OracleParameter("RETURN", OracleType.VarChar, 1000);
                    codeReturn.Direction = ParameterDirection.ReturnValue;
    
    
                    OracleParameter code1 = new OracleParameter("V_RECORD_ID", OracleType.Number);
                    code1.Direction = ParameterDirection.Input;
                    if (obj.RecordId != null)
                        code1.Value = obj.RecordId;
                    else
                        code1.Value = DBNull.Value;
    
    
                    OracleParameter code2 = new OracleParameter("V_DEBIT_APAC", OracleType.VarChar, 200);
                    code2.Direction = ParameterDirection.Input;
                    if (obj.P_BENEF_APAC != null)
                        code2.Value = obj.P_BENEF_APAC;
                    else
                        code2.Value = DBNull.Value;
    
    
                    OracleParameter code3 = new OracleParameter("V_ACCOUNT_TYPE", OracleType.VarChar, 200);
                    code3.Direction = ParameterDirection.Input;
                    if (obj.BenfAccType != null)
                        code3.Value = obj.BenfAccType;
                    else
                        code3.Value = DBNull.Value;
    
                    OracleParameter code4 = new OracleParameter("V_IFSC_CODE", OracleType.VarChar, 200);
                    code4.Direction = ParameterDirection.Input;
                    if (obj.IFSC != null)
                        code4.Value = obj.IFSC;
                    else
                        code4.Value = DBNull.Value;
    
    
                    objCom.Parameters.Add(codeReturn);
                    objCom.Parameters.Add(code1);
                    objCom.Parameters.Add(code2);
                    objCom.Parameters.Add(code3);
                    objCom.Parameters.Add(code4);
    
                    try
                    {
                        objCon.Open();
    
                        objCom.ExecuteNonQuery();
    
                        strRetrun = objCom.Parameters["RETURN"].Value.ToString();
                    }
                    catch
                    {
    
                    }
                    finally
                    {
                        objCon.Close();
                    }
    
                }
            }
    
    
            return strRetrun;
