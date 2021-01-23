    public class MyClass
    {
        public int GetSum
        {
            get { return Field1 + Field2 + Field3 + Field4; }
        }
    }
    
    criteria.Add(Restrictions.Where<MyClass>(x => x.GetSum > myVariable));
