        public void bulkCopy(String tmpTableName, DataTable table)
        {
            using (SqlBulkCopy bulkCopy =
                           new SqlBulkCopy((SqlConnection)connection))
            {
                bulkCopy.DestinationTableName = tmpTableName;
                bulkCopy.WriteToServer(table);
            }
        }
