        public void RemoteCmd(ref PicMeta pm)
        {
	    iDB2Connection cn;
            try
            {
                using (cn = new iDB2Connection("DataSource=<servername/IP>; UserID="<user>"; Password="<pass>";"))
                {
                    cn.Open();
                    using (iDB2Command cm = cn.CreateCommand())
                    {
                        //Place a try/catch here, so it will create the procedure the first time, or any time it has been removed from the 400.  If already set, it will fail, and you'll go directly to the remote command.  
                        try
                        {
                             //Here we create a procedure and execute or continue.
                             cm.CommandText = "CREATE PROCEDURE LIBRARY.SP_PICGETID(INOUT FSET CHAR (1 ), INOUT UNIT CHAR (6 ), INOUT NEXTID CHAR (3 ), INOUT UUID CHAR (36 ))  LANGUAGE RPGLE NOT DETERMINISTIC NO SQL CALLED ON NULL INPUT EXTERNAL NAME LIBRARY.PICGETID PARAMETER STYLE GENERAL";
                             cm.ExecuteNonQuery();
						}
						catch (Exception ex)
						{
							Console.Out.WriteLine(ex.Message);
						}
						
						//Continue - create and call the command     
                        //ParameterDirection needs "using System.Data;"
						cm.CommandTimeout = 0;
						cm.CommandType = System.Data.CommandType.StoredProcedure;
						cm.CommandText = "LIBRARY.SP_PICGETID";
						iDB2Parameter p = new iDB2Parameter();
						p.ParameterName = "FSET";
						p.Direction = ParameterDirection.Input;
						p.iDB2DbType = iDB2DbType.iDB2Char;
						p.Size = 1;
						p.iDB2Value = pm.fileset;
						cm.Parameters.Add(p);
						p = new iDB2Parameter();
						p.ParameterName = "UNIT";
						p.Direction = ParameterDirection.Input;
						p.iDB2DbType = iDB2DbType.iDB2Char;
						p.Size = 6;
						p.iDB2Value = pm.unit;
						cm.Parameters.Add(p);
						p = new iDB2Parameter();
						p.ParameterName = "NEXTID";
						p.Direction = ParameterDirection.InputOutput;
						p.iDB2DbType = iDB2DbType.iDB2Char;
						p.Size = 3;
						p.iDB2Value = "";
						cm.Parameters.Add(p);
						p = new iDB2Parameter();
						p.ParameterName = "GUUID";
						p.Direction = ParameterDirection.InputOutput;
						p.iDB2DbType = iDB2DbType.iDB2Char;
						p.Size = 36;
						p.iDB2Value = "";
						cm.Parameters.Add(p);
						cm.ExecuteNonQuery();
						iDB2ParameterCollection pc = cm.Parameters;
	                                        
                        //We get our Out parameters here 
						pm.nextid = pc["NEXTID"].Value.ToString();
						pm.uuid = pc["GUUID"].Value.ToString();
                    }
	                cn.Close();
                }
            }
            catch (Exception e)
            {
                Console.Out.WriteLine(e.Message);
            }
            return;
        }
