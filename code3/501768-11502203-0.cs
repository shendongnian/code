    public TestType GetTestType(string testTypeName)
    {
       switch(testTypeName)
       {
           case "Military 888d Test":
               return TestType.Mil;
           case "IEEE 1394":
               return TestType.IEEE;
           default:
               throw new ArgumentException("testTypeName");
       }
    }
