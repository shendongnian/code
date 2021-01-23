     public T GetValue<T>(string PropertyName, T DefaultValue)
     {
     }
     .... return GetValue("Prop1", 4); //T = int
     .....return GetValue("Prop2", string.Empty) //T= string
     //for nullable times, you can always include the generic parameter
     GetValue<int[]>("Prop3",null);
     //or by 'strongly typing' the null value:
     GetValue("Prop3", (int[])null); //for set this isn't a problem, since 'value' already is strongly typed
