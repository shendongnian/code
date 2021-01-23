     public DataTable gridviewToDataTable(GridView gv)
            {
    
                DataTable dtCalculate = new DataTable("TableCalculator");
    
                // Create Column 1: Date
                DataColumn dateColumn = new DataColumn();
                dateColumn.DataType = Type.GetType("System.DateTime");
                dateColumn.ColumnName = "date";
    
                // Create Column 3: TotalSales
                DataColumn loanBalanceColumn = new DataColumn();
                loanBalanceColumn.DataType = Type.GetType("System.Double");
                loanBalanceColumn.ColumnName = "loanbalance";
    
    
                DataColumn offsetBalanceColumn = new DataColumn();
                offsetBalanceColumn.DataType = Type.GetType("System.Double");
                offsetBalanceColumn.ColumnName = "offsetbalance";
    
    
                DataColumn netloanColumn = new DataColumn();
                netloanColumn.DataType = Type.GetType("System.Double");
                netloanColumn.ColumnName = "netloan";
    
    
                DataColumn interestratecolumn = new DataColumn();
                interestratecolumn.DataType = Type.GetType("System.Double");
                interestratecolumn.ColumnName = "interestrate";
    
                DataColumn interestrateperdaycolumn = new DataColumn();
                interestrateperdaycolumn.DataType = Type.GetType("System.Double");
                interestrateperdaycolumn.ColumnName = "interestrateperday";
    
                // Add the columns to the ProductSalesData DataTable
                dtCalculate.Columns.Add(dateColumn);
                dtCalculate.Columns.Add(loanBalanceColumn);
                dtCalculate.Columns.Add(offsetBalanceColumn);
                dtCalculate.Columns.Add(netloanColumn);
                dtCalculate.Columns.Add(interestratecolumn);
                dtCalculate.Columns.Add(interestrateperdaycolumn);
    
                foreach (GridViewRow row in gv.Rows)
                {
                    DataRow dr;
                    dr = dtCalculate.NewRow();
    
                    dr["date"] = DateTime.Parse(row.Cells[0].Text);
                    dr["loanbalance"] = double.Parse(row.Cells[1].Text);
                    dr["offsetbalance"] = double.Parse(row.Cells[2].Text);
                    dr["netloan"] = double.Parse(row.Cells[3].Text);
                    dr["interestrate"] = double.Parse(row.Cells[4].Text);
                    dr["interestrateperday"] = double.Parse(row.Cells[5].Text);
    
                    
                    dtCalculate.Rows.Add(dr);
                }
    
    
    
                return dtCalculate;
            }
