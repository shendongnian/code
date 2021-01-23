    List<DataRow> rowsToRemove = new List<DataRow>();
            foreach (DataRow dr in resE1.Rows)
            {
                if (dr["Name"].ToString().IndexOf("null") == 0)
                {
                    dr.SetField("Name", "");
                }
                bool hasValue = false;
                for (int i = 0; i < dr.ItemArray.Count(); i++)
                {
                    if (!dr[i].ToString().Equals(String.Empty))
                       hasValue = true;
                }
                if (!hasValue) rowsToRemove.Add(dr);
            }
            foreach(DataRow dr in rowsToRemove)
            {
                dr.Delete();
            }
