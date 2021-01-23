        Debug.WriteLine(ConvertDate.ToFa(DateTime.Now));//1393/08/01
        
        Debug.WriteLine(ConvertDate.ToFa(DateTime.Now, "d"));//93/08/01 
    Debug.WriteLine(ConvertDate.ToFa(DateTime.Now, "D"));//پنج شنبه, 01 آبان 1393
        
        Debug.WriteLine(ConvertDate.ToFa(DateTime.Now, "t"));//21:53 
    Debug.WriteLine(ConvertDate.ToFa(DateTime.Now, "T"));//21:53:26
        
        Debug.WriteLine(ConvertDate.ToFa(DateTime.Now, "g"));//93/08/01 21:53 
    Debug.WriteLine(ConvertDate.ToFa(DateTime.Now, "G"));//93/08/01 21:53:26
        
        Debug.WriteLine(ConvertDate.ToFa(DateTime.Now, "f"));//پنج شنبه, 01 آبان 1393 21:53 
    Debug.WriteLine(ConvertDate.ToFa(DateTime.Now, "F"));//پنج شنبه, 01 آبان 1393 21:53:26
        
        Debug.WriteLine(ConvertDate.ToFa(DateTime.Now, "m"));//آبان 1 
    Debug.WriteLine(ConvertDate.ToFa(DateTime.Now, "y"));//1393 آبان
        
        string persiandate = ConvertDate.ToFa(DateTime.Now);//1393/08/01
        
        Debug.WriteLine(ConvertDate.ToEn(persiandate));//2014/10/23 00:00:00
