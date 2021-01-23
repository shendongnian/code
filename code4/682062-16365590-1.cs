    enum DateItemKind
    {
        ExpiryDate,
        CreatedDate
    }
    class DateItem
    {
        public DateTime DateTime { get; set; }
        public DateItemKind Kind { get; set; }
    }
    void DoSomething(DateItem dateItem)
    {
        ...
