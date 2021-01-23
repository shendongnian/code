            using (var reader = database1DataSet.DataTable1.CreateDataReader())
            {
                int colOrdinal = database1DataSet.DataTable1.Columns["YourColumnName"].Ordinal
                while (reader.Read())
                {
                    chart1.Series["ser1"].Points.AddY(reader.GetInt32(colOrdinal));
                }
            }
