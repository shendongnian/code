    public class MyBase
    {
        public override string ToString()
        {
            return "I'm a base class";
        }
    }
    public class MyFixedChild : MyBase
    {
        public override string ToString()
        {
            return "I'm the fixed child class";
        }
    }
    public class MyFlexiChild : MyBase
    {
        public new string ToString()
        {
            return "I'm the flexi child class";
        }
    }
	public class MyTestApp
	{
		public static void main()
		{
			MyBase myBase = new MyBase();
			string a = myBase.ToString();                 // I'm a base class
			MyFixedChild myFixedChild = new MyFixedChild();
			string b = myFixedChild.ToString();           // I'm the fixed child class
			string c = ((MyBase)myFixedChild).ToString(); // I'm the fixed child class
			MyFlexiChild myFlexiChild = new MyFlexiChild();
			string d = myFlexiChild.ToString();           // I'm the flexi child class
			string e = ((MyBase)myFlexiChild).ToString(); // I'm a base class
		}
	}
		
