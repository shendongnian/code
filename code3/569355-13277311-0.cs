    public IEnumerable<DateTime> GetDaysLikeMe(DateTime currentDate)
    {
        DateTime temp = currentDate;
        while(true)
        {
            temp = temp.AddDays(-7);
            yield return temp;
        }
    }
