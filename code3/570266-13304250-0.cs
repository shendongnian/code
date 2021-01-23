    public class DayValue
    {
        public DateTime Day { get; set; }
        public object Value { get; set; }
    }
    var list = new List<DayValue>();
    list.Add(new DayValue { Day = new DateTime(2012, 11, 1), Value = "Value1" });
    list.Add(new DayValue { Day = new DateTime(2012, 11, 3), Value = "Value2" });
    list.Add(new DayValue { Day = new DateTime(2012, 11, 5), Value = "Value3" });
    var result = Enumerable.Range(0, 31).Select(
        index => (list.FirstOrDefault(item => item.Day.Day == index) ?? new DayValue()).Value).ToArray();
