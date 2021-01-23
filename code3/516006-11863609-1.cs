    public static DataTable CompareTwoDataTable(DataTable dt1, DataTable dt2)
            {
                dt1.Merge(dt2);
                DataTable d3 = dt2.GetChanges();
    
                return d3;
            }
