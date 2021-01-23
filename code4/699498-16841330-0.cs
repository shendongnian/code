    public class MyData
    {
        public MyData() { }
        public MyData(string[] values)
        {
            ValueOne = double.Parse(values[0]);
            ValueTwo = double.Parse(values[1]);
            ValueThree = double.Parse(values[2]);
        }
        public double ValueOne { get; set; }
        public double ValueTwo { get; set; }
        public double ValueThree { get; set; }
    }
