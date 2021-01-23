        public class myClass
        {
            int _id;
            public myClass(int id)
            {
                Id = id;
            }
            public int Id
            {
                get
                {
                    return _id;
                }
                set
                {
                    _id = value;
                }
            }
        }
        public void BuildList()
        {
            List<myClass> myClassList1 = new List<myClass>();
            myClassList1.Add(new myClass(8));
            myClassList1.Add(new myClass(4));
            myClassList1.Add(new myClass(10));
            myClassList1.Add(new myClass(1));   // This would become the first item when the list is sorted.
            myClassList1.Add(new myClass(30));
            
            List<myClass> myClassList2 = new List<myClass>();
            foreach (myClass obj in myClassList1)
            {
                myClassList2.Add(obj);
            }
            myClassList2.Sort((s1, s2) => s1.Id.CompareTo(s2.Id));  // Sort by Id.
            // Modify the first element in the second sorted list.
            myClass firstElementList2 = myClassList2[0];
            firstElementList2.Id++;
            int valueInList2 = firstElementList2.Id; // Get the id that is incremented
            // Find the same object in first list...
            myClass sameElementInList1 = myClassList1.Find(x => x.Id.Equals(valueInList2));
            int valueInList1 = sameElementInList1.Id;
            if (valueInList2== valueInList1)
            {
                MessageBox.Show("Cheers!");
            }
        }
