    public class DateTimeList : List<DateTime> {
    public void InsertDateTime (int position, DateTime dateTime) {
        
        // insert the new object
        this.InsertAt(position, dateTime)
        // then take the adjacent objects (take care of integrity checks i.e.
        // exists the index/object? in not null ? etc.        
        DateTime previous = this.ElementAt<DateTime>(position - 1);
        // modify the previous DateTime obejct according to your needs.
        DateTime next = this.ElementAt<DateTime>(position + 1);
        // modify the next DateTime obejct according to your needs.    
    }
    }
