    public class A 
    { 
       //Common Stuff
    }
    public class AFirstType : A
    {
        public int SomeInt {get;set;}
    }
    public class ASecondType : A
    {
        public string SomeString {get;set;}
    }
    
    public class AFactory 
    {
        public static void Create(byte[] Data)
        {
            //analyze data
            if (BoolFromAnalyzedData == true)
            {
                return new AFirstType() 
                           {
                               SomeInt = IntFromAnalyzedData
                           };
            }
            else
            {
                return new  ASecondType() 
                            {
                               SomeString = StringFromAnalyzedData
                            };
            }
        }
    }
    
    ///Main Code
    
    byte [] data = GetData();
    A someA = AFactory.Create(data);
    if (a is AFirstType)
        DoStuff((a as AFirstType).SomeInt);
    else if (a is ASecondType)
        DoStuff((a as ASecondType).SomeString);
