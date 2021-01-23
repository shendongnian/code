    var jsonresponseArray= WhatEverJSONConvertor(JSONString);
    
    for (int i = 0; i < DynamicArray.length; i++)
    {
          Console.WriteLine(jsonresponseArray[i].AFieldInTheObject);
    }
    ....
    public dynamic[] WhatEverJSONConvertor(string json){
       // parse and create a dynamic type object
    }
