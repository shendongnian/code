    public interface IFamily
    {
       int field1;
       int Dosth();
    }
    public class Father : AbstractA, IFamily
    {
       // Implementation goes here
       int field1;
       int Dosth() {
          // Do magic
       }
    }
    public class Son : AbstractB, IFamily
    {
       // Implementation goes here
       int field1;
       int Dosth() {
          // Do magic
       }
    }
