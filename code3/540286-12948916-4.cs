        void BindGrid(DataTable Data)
        {
         try
         {
          // Adding one check box
          DataGridViewCheckBoxColumn chkSelection = new DataGridViewCheckBoxColumn();
          chkSelection.Name = "Selection";
          dgItemsForBuyBackGrid.Columns.Add(chkSelection);
          int intCount = Data.Rows.Count;
          if (i==true)
          {
           if (intCount > 0)
           {
             ExcelGrid.DataSource = Data;
             ExcelGrid.BindPage();
           }
            else
           {
              ExcelGrid.DataSource = null;
              ExcelGrid.BindPage();
              return;
           }
          // Here I am setting Grid colomns properties this name should equal to Excel //column names.
           ExcelGrid.Columns["BI"].ReadOnly = true;
           ExcelGrid.Columns["AAA"].ReadOnly = true;
           ExcelGrid.Columns["AAB"].ReadOnly = true;
           ExcelGrid.Columns["AAC"].ReadOnly = true;
           ExcelGrid.Columns["AAD"].ReadOnly = true;
           ExcelGrid.Columns["AAE"].ReadOnly = true;
           ExcelGrid.Columns["AAF"].ReadOnly = true;
           ExcelGrid.Columns["AAG"].ReadOnly = false;
          }
          else
          {
             // Some Code
            }
         }
          catch (Exception ex)
          {
          }
        }
       }
      }
