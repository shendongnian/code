    public void setValue(string val, Type type);//move this to your base class
    
        Class MyValue{
    private string strVal;
    private int intVal;
    
    //constructor
    MyValue(string val, Type type){
         //check the type enum here and set the values accordingly
    }
    }
    
    then when set values
    foreach (var item in ListOfBaseClasses)
    {
         item.setValue = MyValue("",Type.INT);
    }
