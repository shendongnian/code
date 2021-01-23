    public class Employee : IDataObject
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public decimal Salary { get; set; }
 
        public void FillFromRow(DataRow row)
        {
            ID = (int)row["ID"];
            Name = (string)row["Name"];
            Salary = (decimal)row["Salary"];
        }
    }
