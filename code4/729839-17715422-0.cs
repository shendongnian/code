                OleDbCommand cal = test.CreateCommand();
                int q;
                int count = int.Parse(AppList.Rows.Count.ToString());
                for (q = 0; q < count - 1; q++)
                {
                    int x = 111 + q;
                    cal.CommandText = "SELECT * FROM Energy_Audit WHERE RecordID=" + x;
                    cal.CommandType = CommandType.Text;
                    OleDbDataReader ObjReader = cal.ExecuteReader();
                    while (ObjReader.Read())
                    {
                        double r = Double.Parse(ObjReader.GetValue(2).ToString());
                        double w = Double.Parse(ObjReader.GetValue(3).ToString());
                        double t = Double.Parse(ObjReader.GetValue(4).ToString());
                        double i = r * w * t * 30 / 1000;
                        ObjReader.Close();
                    }
