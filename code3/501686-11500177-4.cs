    public class MyObject
    {
        public IEnumerable<employee> FindPaging(string job, int startIndex, int pageSize, string sortColumn)
        {
            var c = new DataClassesDataContext();
            var sort = string.Empty;
    
            if (string.IsNullOrWhiteSpace(sortColumn) || sortColumn == "sortColumn")
            {
                sort = "fname";
            }
            else
            {
                sort = sortColumn.Replace("sortColumn ", string.Empty);
                sort = sort.Replace(" DESC", string.Empty);
            }
    
            var q = c.employees.Where(x => x.job_id.ToString() == job).Skip(startIndex).Take(pageSize);
    
            if (!sortColumn.Contains("DESC"))
            {
                return q.OrderBy(sort);
            }
            else
            {
                return q.OrderByDescending(sort);
            }
        }
    
        public int FindPagingCount(string job, int startIndex, int pageSize, string sortColumn)
        {
            var c = new DataClassesDataContext();
    
            return c.employees.Where(x => x.job_id.ToString() == job).Count();
        }
    }
