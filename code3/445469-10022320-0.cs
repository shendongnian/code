    public class Departments
    {
        public string Department;
        public MyList buys;
        public Departments()
        {
            buys = new MyList(this, 5);
        }
    }
    public class MyList
    {
        private double[] backingList;
        private Departments owner;
        public MyList(Departments owner, int size)
        {
            this.owner = owner;
            backingList = new T[size];
        }
        public double this[int index]
        {
            get{ return backingList[index]; }
            set { backingList[index] = discountFor(owner.Department) * value; }
        }
        private float discountFor(string department)
        {
            switch(department)
            {
            case "department1":
                return 0.5f;
            //...
            default:
                 return 1.0f;
            }
        }
    }
