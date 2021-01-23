    public class Student : IComparable
    {
        public int StudentID { get; set; }
        public string Name { get; set; }
        public List<Fee> Fees { get; set; }
        private decimal TotalAmount
        {
            get
            {
                decimal total = 0;
                if (Fees != null)
                    foreach (var fee in Fees)
                        total += fee.FeeAmount;
                return total;
            }
        }
        public int CompareTo(object obj)
        {
			//Ascending
            //return TotalAmount.CompareTo((obj as Student).TotalAmount);
			//Descending
            return (obj as Student).TotalAmount.CompareTo(TotalAmount);
        }
    }
    public class Fee
    {
        public int FeeID { get; set; }
        public decimal FeeAmount { get; set; }
    }
	List<Student> students = new List<Student>();
	...
	students.Sort();
