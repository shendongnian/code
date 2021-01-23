    [StructLayout...
    class MyClass
    {
      //some properties
      
      //parameterless constructor
      public void MyClass()
      {
        size = ...;
        //initialize properties as needed
      }
    }
   
    ...
    public static extern bool SetData([In, MarshalAs(UnmanagedType.LPStruct)]  MyStruct ms); //no ref for class
