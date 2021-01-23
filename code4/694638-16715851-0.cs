    MyFunction(DateTime? abc)
    {
       if(abc.HasValue)
       {
         DateTime myDate = abc.Value;
       } else {
         // abc is null
       }
    }
