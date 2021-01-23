    class A
    {
        private List<int> myList;
    	private readonly object _lockObject = new Object();
    
        public void SomeMethodA()
        {
           lock(_lockObject)
           {
              //...
           }
        }
    
        public void SomeMethodB()
        {
           lock(_lockObject)
    	   {
    		   myList.Add(1);
    	   }
        }
    }
