    class Program
    {
        static void Main(string[] args)
        {
            var totalOfAllAges = 0D;
            var rows = new ExcelRows();
            
            //calculate various statistics
            foreach (var item in rows.GetRow())
            {
                totalOfAllAges += item.Age;
            }
            Console.WriteLine("The total of all ages is {0}", totalOfAllAges);
        }
    }
    internal class ExcelRows
    {
        private double rowCount = 1500000D;
        private double rowIndex = 0D;
        public IEnumerable<ExcelRow> GetRow()
        {
            while (rowIndex < rowCount)
            {
                rowIndex++;
                yield return new ExcelRow() { Age = rowIndex };
            }
        }
    }
    /// <summary>
    /// represents the next read gathered by VSTO
    /// </summary>
    internal class ExcelRow
    {
        public double Age { get; set; }
    }
