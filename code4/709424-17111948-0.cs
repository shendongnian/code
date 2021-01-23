    public static string OrderByClauseBuilder(string parmSortByColumn)
    {
        if (parmSortByColumn.LastIndexOf(",") > -1) { 
            parmSortByColumn = parmSortByColumn.Substring(0, parmSortByColumn.LastIndexOf(","));
        }
        return parmSortByColumn;
    }
