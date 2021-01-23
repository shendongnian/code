    public static class Paging
    {
        public static DataTable Page(this IEnumerable<DataRow> dataTableQuery, int pageSize, int pageNumber, out int totalrecords)
        {
            int skip = (pageNumber - 1) * pageSize;
    
            var queryConverted = dataTableQuery.Skip(skip).Take(pageSize);
    
            if (queryConverted.Count() > 0)
            {
                totalrecords = query.Count();
    
                return queryConverted.CopyToDataTable();
            }
            totalrecords = 0;
    
            return new DataTable();
        }
    }
