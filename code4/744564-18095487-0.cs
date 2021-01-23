        class Program
    {
        static void Main(string[] args)
        {
            List<filesdetail> details = new List<filesdetail>();
            details.Add(new filesdetail() { truckno = "123", deliveryno = "abc" });
            details.Add(new filesdetail() { truckno = "123", deliveryno = "abc" });
            var a = details.Distinct(new filesdetailComparer<filesdetail>()).ToList();
        }
    }
    public class filesdetailComparer<T> : IEqualityComparer<T>
    {
        public bool Equals(T x, T y)
        {
            var obj1 = x as filesdetail;
            var obj2 = y as filesdetail;
            if (obj1 != null && obj2 != null && string.Compare(obj1.deliveryno, obj2.deliveryno) == 0 && string.Compare(obj1.truckno, obj2.truckno) == 0)
                return true;
            else
                return false;
        }
        public int GetHashCode(T obj)
        {
            var obj1 = obj as filesdetail;
            //Check whether the object is null 
            if (Object.ReferenceEquals(obj1, null)) return 0;
            //Get hash code for the truckno field if it is not null. 
            int hashtruckno = obj1.truckno == null ? 0 : obj1.deliveryno.GetHashCode();
            //Get hash code for the deliveryno field. 
            int hashdeliveryno = obj1.deliveryno == null ? 0 : obj1.deliveryno.GetHashCode();
            //Calculate the hash deliveryno for the filesdetail. 
            return hashtruckno ^ hashdeliveryno;
        }
    }
    public class filesdetail
    {
        public string truckno { get; set; }
        public string deliveryno { get; set; }
    }
