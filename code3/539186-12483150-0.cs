            var dt = new DataTable
            {
                Columns =
                    {
                        new DataColumn("Id", typeof(int)),
                        new DataColumn("FirstName", typeof(string)) { AllowDBNull = true },
                        new DataColumn("LastName", typeof(string)) { AllowDBNull = true },
                    }
            };
            var row = dt.NewRow();
            row.ItemArray = "1,,Jones".Split(',').Select(s => string.IsNullOrEmpty(s) ? (object)DBNull.Value : (object)s).ToArray();
            dt.Rows.Add(row);
