          public void app()
          {
            try
            {
                DataTable dtInput = new DataTable();
                DataRow drRow;
                dtInput.Columns.Add("ID");
                dtInput.Columns.Add("Name");
                drRow = dtInput.NewRow();
                drRow["ID"] = 1;
                drRow["Name"] = "Star";
                dtInput.Rows.Add(drRow);
                dtInput.TableName = "Input";//Table name is mandatory to avoid serialization exception 
                DataTable dtOutput = new DataTable();
                dtOutput.TableName = "Output";//Table name is mandatory to avoid serialization exception 
                service.TestService(dtInput ,ref dtOutput);
            }
            catch (Exception ex)
            {
            }
          } 
