            OracleHelper.OracleDBOpen();
            object flag = OracleHelper.OracleExecuteScalar("your select Query ");
            if (flag == null)
            {
                          showMessage("Failed !!! ");
            }
            else
            {
                string reg = String.Format("your Insert Query ");
                
                showMessage("successfuly");
                OracleHelper.OracleExecuteNonQuery(reg);
                
            }                
            OracleHelper.OracleDBClose();
        }
    }
