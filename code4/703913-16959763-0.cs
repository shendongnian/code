    public enum Status
    {
        Success,
        Pending,
        Error
    }
    var sortedList = myList.OrderBy(x => x.Status);
    // sort by Success, Pending and then Error
    var sortedList = myList.OrderByDescending(x => x.Status);
    // sort by Error, Pending, Success
