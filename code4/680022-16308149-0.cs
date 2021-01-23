    string strParameter = txtAutoComplete.Text.ToLower();
            
                        
            //WUG TableAdapter and DataTable
            dsCIInfoTableAdapters.DeviceTableAdapter taWUG;
            taWUG = new dsCIInfoTableAdapters.DeviceTableAdapter();
            dsCIInfo.DeviceDataTable dtWUG = new dsCIInfo.DeviceDataTable();
            taWUG.Fill(dtWUG);
            
            var qstWUG = (from row in dtWUG.AsEnumerable()
                          let display = row.Field<string>("sDisplayName")
                          where display.ToLower().Contains(strParameter)
                          select display).ToArray();
