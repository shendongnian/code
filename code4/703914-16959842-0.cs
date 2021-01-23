    public class MyItem : IComparable<MyItem>
    {
        public string OrderItem { get; set; }
        public string Status { get; set; }
        public int CompareTo(MyItem other)
        {
            if (other == null)
            {
                return 1;
            }
            if (other.Status == this.Status)
            {
                return 0;
            }
            var statusAsInt = this.Status == "Error" ? 0 : (this.Status == "Pending" ? 1 : 2);
            var otherStatusAsInt = other.Status == "Error" ? 0 : (other.Status == "Pending" ? 1 : 2);
            
            if (statusAsInt == otherStatusAsInt)
            {
                return 0;
            }
            return statusAsInt < otherStatusAsInt ? -1 : 1;
        }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            var myItems = new List<MyItem> { new MyItem { Status = "Pending" }, new MyItem { Status = "Error" }, new MyItem { Status = "Success " } };
            myItems.Sort();
            foreach (var myItem in myItems)
            {
                Console.WriteLine(myItem.Status);
            }    
        }
    }
