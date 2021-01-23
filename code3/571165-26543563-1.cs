       //default format 
        string dts=ConvertDate.ToFa(DateTime.Now);//1393/08/01
        //date only (short and D for Long)
        dts=ConvertDate.ToFa(DateTime.Now, "d");//93/08/01 
        dts=ConvertDate.ToFa(DateTime.Now, "D");//پنج شنبه, 01 آبان 1393
        //time only 
        dts=ConvertDate.ToFa(DateTime.Now, "t");//21:53 
        dts=ConvertDate.ToFa(DateTime.Now, "T");//21:53:26
        //general short date + time
        dts=ConvertDate.ToFa(DateTime.Now, "g");//93/08/01 21:53 
        dts=ConvertDate.ToFa(DateTime.Now, "G");//93/08/01 21:53:26
        //general full date + time
        dts=ConvertDate.ToFa(DateTime.Now, "f");//پنج شنبه, 01 آبان 1393 21:53 
        dts=ConvertDate.ToFa(DateTime.Now, "F");//پنج شنبه, 01 آبان 1393 21:53:26
        //only month and year
        dts=ConvertDate.ToFa(DateTime.Now, "m");//آبان 1 
        dts=ConvertDate.ToFa(DateTime.Now, "y");//1393 آبان
        
        dts=ConvertDate.ToFa(DateTime.Now);//1393/08/01
        // converting back to Gregorian date 
        Datetime dt= ConvertDate.ToEn(dts);//2014/10/23 00:00:00
