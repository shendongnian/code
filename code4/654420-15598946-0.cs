     enum MyEnum{
         A,B
    }
    void Main()
    {
        MyEnum 	myEnum = MyEnum.B; //Assign a variable
	 
        DoSomethingByEnum(myEnum); //Pass myEnum
        DoSomethingDynamicByValue(myEnum); //pass myEnum to a dynamic parameter
	
        dynamic dyn = myEnum;      //assign myenum to a dynamic variable
        DoSomethingDynamicByRef(ref dyn);	 //pass it as a reference
    }
    MyEnum DoSomethingByEnum(MyEnum a)
    {
       return a;
    }
    dynamic DoSomethingDynamicByValue(dynamic inputObject)
    {
       return inputObject;
    }
    dynamic DoSomethingDynamicByRef(ref  dynamic inputObject)
    {
      return inputObject;
    } 
   
