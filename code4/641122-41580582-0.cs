    private void AssertTableRecordsAreEqual(DataTable expectedTable, DataTable actualTable)
        {
            Assert.IsNotNull(actualTable, "Table is empty");
            Assert.AreEqual(expectedTable.Columns.Count, actualTable.Columns.Count, "Number of columns in actual and expected tables are different");
            Assert.AreEqual(expectedTable.Rows.Count, actualTable.Rows.Count, "Number of records in actual and expected tables are different");
            Assert.IsFalse(expectedTable.Columns.Cast<DataColumn>().Any(dc => !actualTable.Columns.Contains(dc.ColumnName)), "Table column names are different");
            for (int i = 0; i <= expectedTable.Rows.Count - 1; i++)
            {
                Assert.IsFalse(expectedTable.Columns.Cast<DataColumn>().Any(dc1 => expectedTable.Rows[i][dc1.ColumnName].ToString() != actualTable.Rows[i][dc1.ColumnName].ToString()), "Table row value is different");
            }
        }
