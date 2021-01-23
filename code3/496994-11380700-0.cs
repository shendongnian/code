        static void Main(string[] args)
		{
			Parent_class test = new Parent_class();
			test.Number = 3;            //<--Ok
			test.ChildClass = new Child_class(); 
			test.Childclass.Number = 4; //<--NullReferenceException
		}
