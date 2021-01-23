    public abstract class A
    {
      private int _theVitalValue;
      public A()
      {
    	_theVitalValue = TheValueDecider();
      }
      protected abstract int TheValueDecider();
      public int TheImportantValue
      {
    	get { return _theVitalValue; }
      }
    }
    public class B : A
    {
      private readonly int _theValueMemoiser;
      public B(int val)
      {
    	_theValueMemoiser = val;
      }
      protected override int TheValueDecider()
      {
    	return _theValueMemoiser;
      }
    }
    void Main()
    {
      B b = new B(93);
      Console.WriteLine(b.TheImportantValue); // Writes "0"!
    }
