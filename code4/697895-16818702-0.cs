    public List<fMonthly_Result> GetMonthlyData2(string aStart, string aEnd)
    {
        using (SSRSReportsEntities re = new SSRSReportsEntities())
        {
            DateTime dstart = DateTime.Parse(aStart);
            DateTime dend = DateTime.Parse(aEnd);
    
            return re.fMonthly(dstart, dend, null).ToList();
        }
    }
