                dataAdapter.Fill(DataTable);
                if (Cache["PoliceData"] == null)
                {
                    Cache.Insert("PoliceData", DataTable);
                }
                else
                {
                    Cache.Remove("PoliceData");
                    Cache.Insert("PoliceData", DataTable);
                }
