            SqlCommand cmd = new SqlCommand("//Your Query//");
            //SqlCommand cmd = new SqlCommand();
            //cmd.CommandText = "GetSalesCrystalReport";
            //cmd.CommandType = CommandType.StoredProcedure;
            //cmd.Parameters.AddWithValue("@ReferenceNo", txtReferenceNo.Text);
            DataTable dt1 = DataManager.GetDataTable(cmd);
            Sales objRpt3 = new Sales();
            objRpt3.SetDataSource(dt1);
            objRpt3.PrintToPrinter(1, false, 0, 0);
            
        {
       }
            
        }
