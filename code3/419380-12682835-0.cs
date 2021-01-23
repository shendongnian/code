    using System.Collections.ObjectModel;
    
    namespace IntIntKeyedCollection
    {
        class Program
        {
            static void Main(string[] args)
            {
                UInt16UInt16O Emp1 = new UInt16UInt16O(34, 1990);
                Emp1.PayIDs.Add(1);
                Emp1.PayIDs.Add(2);
                UInt16UInt16O Emp2 = new UInt16UInt16O(34, 1990, new List<byte>{3,4});
                if (Emp1 == Emp2) Console.WriteLine("same");
                if (Emp1.Equals(Emp2)) Console.WriteLine("Equals");
                Console.WriteLine("Emp1.GetHashCode " + Emp1.GetHashCode().ToString());
    
                UInt16UInt16OCollection Employees = new UInt16UInt16OCollection();
                Employees.Add(Emp1);
                //this would fail
                //Employees.Add(Emp2);
                Employees.Add(new UInt16UInt16O(35, 1991, new List<byte> { 1 } ));
                Employees.Add(new UInt16UInt16O(35, 1992, new List<byte> { 1, 2 } ));
                Employees.Add(new UInt16UInt16O(36, 1992));
    
                Console.WriteLine(Employees.Count.ToString());
                // reference by ordinal postion (note the is not the long key)
                Console.WriteLine(Employees[0].GetHashCode().ToString());
                // reference by Int32 Int32
                Console.WriteLine(Employees[35, 1991].GetHashCode().ToString());
                Console.WriteLine("foreach");
                foreach (UInt16UInt16O emp in Employees)
                {
                    Console.WriteLine(string.Format("HashCode {0} EmpID {1} Year {2} NumCodes {3}", emp.GetHashCode(), emp.EmpID, emp.Year, emp.PayIDs.Count.ToString()));
                }
                Console.WriteLine("sorted");
                foreach (UInt16UInt16O emp in Employees.OrderBy(e => e.EmpID).ThenBy(e => e.Year))
                {
                    Console.WriteLine(string.Format("HashCode {0} EmpID {1} Year {2} NumCodes {3}", emp.GetHashCode(), emp.EmpID, emp.Year, emp.PayIDs.Count.ToString()));
                }  
            }
            public class UInt16UInt16OCollection : KeyedCollection<UInt16UInt16S, UInt16UInt16O>
            {
                // This parameterless constructor calls the base class constructor 
                // that specifies a dictionary threshold of 0, so that the internal 
                // dictionary is created as soon as an item is added to the  
                // collection. 
                // 
                public UInt16UInt16OCollection() : base(null, 0) { }
    
                // This is the only method that absolutely must be overridden, 
                // because without it the KeyedCollection cannot extract the 
                // keys from the items.  
                // 
                protected override UInt16UInt16S GetKeyForItem(UInt16UInt16O item)
                {
                    // In this example, the key is the part number. 
                    return item.UInt16UInt16S;
                }
    
                //  indexer 
                public UInt16UInt16O this[UInt16 EmpID, UInt16 Year]
                {
                    get { return this[new UInt16UInt16S(EmpID, Year)]; }
                }
            }
    
            public struct UInt16UInt16S
            {   // required as KeyCollection Key must be a single item
                // but you don't reaaly need to interact with Int32Int32s
                public  readonly UInt16 EmpID, Year;
                public UInt16UInt16S(UInt16 empID, UInt16 year) { this.EmpID = empID; this.Year = year; }
            }
            public class UInt16UInt16O : Object
            {
                // implement you properties
                public UInt16UInt16S UInt16UInt16S { get; private set; }
                public UInt16 EmpID { get { return UInt16UInt16S.EmpID; } }
                public UInt16 Year { get { return UInt16UInt16S.Year; } }
                public List<byte> PayIDs { get; set; }
                public override bool Equals(Object obj)
                {
                    //Check for null and compare run-time types.
                    if (obj == null || !(obj is UInt16UInt16O)) return false;
                    UInt16UInt16O item = (UInt16UInt16O)obj;
                    return (this.EmpID == item.EmpID && this.Year == item.Year);
                }
                public override int GetHashCode() { return ((UInt32)EmpID << 16 | Year).GetHashCode() ; }
                public UInt16UInt16O(UInt16 EmpID, UInt16 Year)
                {
                    UInt16UInt16S uInt16UInt16S = new UInt16UInt16S(EmpID, Year);
                    this.UInt16UInt16S = uInt16UInt16S;
                    PayIDs = new List<byte>();
                }
                public UInt16UInt16O(UInt16 EmpID, UInt16 Year, List<byte> PayIDs)
                {
                    UInt16UInt16S uInt16UInt16S = new UInt16UInt16S(EmpID, Year);
                    this.UInt16UInt16S = uInt16UInt16S;
                    this.PayIDs = PayIDs;
                }
            }
        }
    }
