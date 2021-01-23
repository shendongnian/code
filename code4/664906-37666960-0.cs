    public static bool IsValidDateTime(this string dateString, bool requireTime = false)
    {
        DateTime outDate;
        if(!DateTime.TryParse(dateString, out outDate)) return false;
    
        if (!requireTime) return true;
        else
        {
            return Regex.Replace(dateString, @"\s", "").Length > 7 
    && !DateTime.TryParse(dateString + " 01:01:01.001", out outDate);
        }
    }
    
    public void DateTest()
    {
        var withTimes = new[]{
        "1980/10/11 01:01:01.001",
        "02/01/1980 01:01:01.001",
        "1980-01-01 01:01:01.001",
        "1980/10/11 00:00",
        "1980/10/11 1pm",
        "1980-01-01 00:00:00"};
    
        //Make sure our ones with time pass both tests
        foreach(var date in withTimes){
            Assert.IsTrue(date.IsValidDateTime(), String.Format("date: {0} isn't valid.", date));
            Assert.IsTrue(date.IsValidDateTime(true), String.Format("date: {0} does have time.", date));
        }
    
        var withoutTimes = new[]{
        "1980/10/11",
        "1980/10",
        "1980/10 ",
        "10/1980",
        "1980 01",
        "1980/10/11 ",
        "02/01/1980",
        "1980-01-01"};
    
        //Make sure our ones without time pass the first and fail the second
        foreach (var date in withoutTimes)
        {
            Assert.IsTrue(date.IsValidDateTime(), String.Format("date: {0} isn't valid.", date));
            Assert.IsFalse(date.IsValidDateTime(true), String.Format("date: {0} doesn't have time.", date) );
        }
    
        var bogusTimes = new[]{
        "1980",
        "1980 01:01",
        "80 01:01",
        "1980T01",
        "80T01:01",
        "1980-01-01T01",
        };
    
        //Make sure our ones without time pass the first and fail the second
        foreach (var date in bogusTimes)
        {
            DateTime parsedDate;
            DateTime.TryParse(date, out parsedDate);
            Assert.IsFalse(date.IsValidDateTime(), String.Format("date: {0} is valid. {1}", date, parsedDate));
            Assert.IsFalse(date.IsValidDateTime(true), String.Format("date: {0} is valid. {1}", date, parsedDate));
        }
    }
