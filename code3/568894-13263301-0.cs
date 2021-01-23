    public static class DataYouWant
    {
        /// <summary>
        /// Function which returns the Griddata for json result of jqGrid
        /// </summary>
        public static GridData Getdata<T>(ObjectSet<T> baseList,int currentPage,int rowsPerPage,
        string sortcolumn,
        string sortord,
        string searchQuery,
        string searchColumns)where T: class
        {
            var query = baseList.OrderBy("it." + sortcolumn + " " + sortord);
            string strPredicate = string.Empty;
            dynamic searchvalue = searchQuery;
            if (!string.IsNullOrEmpty(searchColumns))
            {
                var coltype = baseList.EntitySet.ElementType.Members[searchColumns].TypeUsage.EdmType;
                if (CheckIntType(coltype))
                {
                    strPredicate = "it." + searchColumns + " = @" + searchColumns;
                    searchvalue = Convert.ToInt32(searchQuery);
                }
                else
                    strPredicate = "CONTAINS(it." + searchColumns + ",@" + searchColumns + ")";
                query = baseList.Where(strPredicate, new ObjectParameter(searchColumns, searchvalue)).OrderBy("it." + sortcolumn + " " + sortord);
            }
            
            var pageddata = new PagingList<T>(query, currentPage, rowsPerPage);
            return new GridData()
            {
                Page = pageddata.PageIndex + 1,
                Records = pageddata.TotalCount,
                Rows = pageddata,
                Total = pageddata.TotalPages,
                UserData = "ok"
            };
        }
        /// <summary>
        /// Checks the EdmType and 
        /// </summary>
        public static bool CheckIntType(EdmType objEdmType)
        {
            switch (objEdmType.Name)
            {
                case "Int32":
                    return true;break;
                case "Int16":
                    return true;break;
                case "Int64":
                    return true; break;
                case "Decimal":
                    return  true;break;
                default:
                    return false;
                    break;
            }
        }
    }
