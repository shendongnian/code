Create a list of date/stock information values (or objects). You can use a Tuple&lt;Date, double> as a Type or create your own custom class:
    class DataValue
    {
        public DateTime Date { get; set; }
        public double Value { get; set; }
    }
Then just use a List&lt;DataValue>
