    public Tuple<int, int> mobileCounts(DateTime fromDate, DateTime toDate)
    {
        var inTime = _db.UserDeviceDetail.Where(d=> (d.CreatedOn.Month >= fromDate.Month && d.CreatedOn.Day >= fromDate.Day && d.CreatedOn.Year >= fromDate.Year) || (d.CreatedOn.Month <= toDate.Month && d.CreatedOn.Day <= toDate.Day && d.CreatedOn.Year <= toDate.Year));
        int isMobileCount = inTime.Count(d => d.IsMobile);
        int isNotMobileCount = inTime.Count(d => !d.IsMobile);
        return Tuple.Create(isMobileCount,isNotMobileCount);
    }
