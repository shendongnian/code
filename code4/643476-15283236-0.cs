    public class MyImmutable 
    {
       public MyImmutable(int field1, string field2, bool field3)
       {
            Field1 = field1;
            Field2 = field2;
            Field3 = field3;
       }
       public int Field1 { get; private set; }
       public string Field2 { get; private set; }
       public bool Field3 { get; private set; }
    }
