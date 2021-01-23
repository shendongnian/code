    ABC obj=new ABC();
    obj.Name = "NewObject";
    Response.Write(obj.Method1());
    Response.Write(obj.Name);
    
    Response.Write(new ABC().Method1());
    Response.Write(new ABC().Name);
