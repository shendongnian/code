    if(type2 != RenderType.DataUri) {  
        if ((type2 & RenderType.ViewPage) == RenderType.ViewPage)
        {
            Console.WriteLine("ViewPage");
        }
    
    
        if ((type2 & RenderType.GZip) == RenderType.GZip)
        {
            Console.WriteLine("GZip");
        }
    }
