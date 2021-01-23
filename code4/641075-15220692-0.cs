    void Main()
    {
        A a = new A();
        a.dtA = new DataTable("TestTable");
        B b = new B(a.dtA);
        Console.WriteLine(b.TableName); // Same as A.dtA
        Console.WriteLine(a.dtA.TableName);  // Same as internal datatable in B
        a.dtA = new DataTable("SecondTable");
        Console.WriteLine(b.TableName);   // No more the same as A.dtA
        Console.WriteLine(a.dtA.TableName);
    }
    
    // Define other methods and classes here
    public class A
    {
        public DataTable dtA;
    }
    
    public class B
    {
        DataTable dtB{get;set;}
    
        public B(DataTable dt)
        {
            dtB = dt;
        }
        public string TableName
        {
            get{ return dtB.TableName;}
            set{ dtB.TableName = value;}
        }
    }
