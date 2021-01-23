            //Build first Test DT
            DataTable dt1 = new DataTable();
            dt1.Columns.Add("itemID", typeof(string));
            //Build Second Test DT
            DataTable dt2 = new DataTable();
            dt2.Columns.Add("itemID", typeof(string));
            dt2.Columns.Add("itemName", typeof(string));
            //aad 3 DataRows to first DT - ID only
            DataRow dt1_1 = dt1.NewRow();
            dt1_1["itemID"] = "1";
            DataRow dt1_2 = dt1.NewRow();
            dt1_2["itemID"] = "2";
            DataRow dt1_3 = dt1.NewRow();
            dt1_3["itemID"] = "3";
            dt1.Rows.Add(dt1_1);
            dt1.Rows.Add(dt1_2);
            dt1.Rows.Add(dt1_3);
            //aad 3 DataRows to first DT - ID & Name
            DataRow dt2_1 = dt2.NewRow();
            dt2_1["itemID"] = "1";
            dt2_1["itemName"] = "ItemOne";
            DataRow dt2_2 = dt2.NewRow();
            dt2_2["itemID"] = "2";
            dt2_2["itemName"] = "ItemTwo";
            DataRow dt2_3 = dt2.NewRow();
            dt2_3["itemID"] = "3";
            dt2_3["itemName"] = "ItemThree";
            dt2.Rows.Add(dt2_1);
            dt2.Rows.Add(dt2_2);
            dt2.Rows.Add(dt2_3);
            ////////////////////////////////////////////////////////
            //replacing code - quite comact - assumed itemId is PK//
            ////////////////////////////////////////////////////////
            foreach (DataRow dr in dt1.Rows)
            {
                    string strSelect = "[itemID] = '"+ dr["itemID"] +"'";
                    DataRow[] myRow = dt2.Select(strSelect);
                    if (myRow.Length == 1)
                    {
                        dr["itemID"] = myRow[0]["itemName"];
                    }
            }
            /////////////////////////////////////////////////////////////////
            //dt1 now has itemOne, itemTwo and itemThree instead of 1, 2, 3//
            /////////////////////////////////////////////////////////////////
