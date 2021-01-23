    public void ExportCSV(string SQLSyntax, string LeFile, bool Is_Ordre, int TypeDonne)
        {
            try
            {
                using (var connectionWrapper = new Connexion())
                {
                    var connectedConnection = connectionWrapper.GetConnected();
                    SqlDataAdapter da = new SqlDataAdapter(SQLSyntax, connectionWrapper.conn);
                    da.UpdateCommand = connectedConnection.CreateCommand();
                    da.UpdateCommand.XXXX = YYYY; // construct the SQL Command                    
                    DataSet ds = new DataSet();
                    da.Fill(ds, "Emp");
                    DataTable dt = ds.Tables["Emp"];
                    CreateCSVFile(dt, LeFile, Is_Ordre, TypeDonne);
                    //Update all lines, it not save in Database
                    foreach (DataRow row in dt.Rows)
                    {
                        row["IS_IMPORT"] = true;
                    }
                    da.Update(dt);
                }
            }
            catch (Exception excThrown)
            {
                throw new Exception(excThrown.Message);
            }
        }
