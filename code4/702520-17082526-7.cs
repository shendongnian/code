             private System.Data.DataTable GenerateDatatable()
        {
            Range oRng = null;
            // It takes the current activesheet from the workbook. You can always pass any sheet as an argument
            Worksheet ws = this.ActiveSheet as Worksheet;
            // set this value using your own function to read last used column, There are simple function to find last last used column
            int col = 4;
            // set this value using your own function to read last used row, There are simple function to find last last used rows
            int row = 5;
            string strRange = "A1";
            string andRange = "D5";
            System.Array arr = (System.Array)ws.get_Range(strRange, andRange).get_Value(Type.Missing);
            System.Data.DataTable dt = new System.Data.DataTable();
            for (int cnt = 1;
                cnt <= col; cnt++)
                dt.Columns.Add(cnt.Chr(), typeof(string));
            for (int i = 1; i <= row; i++)
            {
                DataRow dr = dt.NewRow();
                for (int j = 1; j <= col; j++)
                {
                    dr[j - 1] = arr.GetValue(i, j).ToString();
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
