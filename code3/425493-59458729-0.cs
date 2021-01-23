    [HttpGet("method1-{item}")]
    public string Method1(var item) { 
    return "hello" + item;}
    
    [HttpGet("method2-{item}")]
    public string Method2(var item) { 
    return "world" + item;}
