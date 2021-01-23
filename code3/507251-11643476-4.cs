    class MyResult {
       string Property1 { get; set;}
       string Property2 { get; set;}
    }
    public MyResult MyMethod(){
        var result = new MyResult();
        result.Property1 = "string1";
        result.Property2 = "string2";
        return result;
    }
