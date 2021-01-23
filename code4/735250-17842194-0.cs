    public class MyObjectWithSum
    {
        public DateTime StartDate {get;set;}
        public DateTime EndDate {get;set;}
        public int Number {get;set;}
        public int SumAsOfEndDate {get;set;}
    }
    var list = new List<MyObjectWithSum>();
    foreach(var item in list)
    {
        item.SumAsOfEndDate = list.Sum(x => x.Number).Where(y => y.EndDate <= item.EndDate);
    }
    
    list.OrderBy(x => x.EndDate).First(x => x.SumAsOfEndDate > 100).EndDate;
