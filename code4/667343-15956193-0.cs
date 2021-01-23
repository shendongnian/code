    public class Rootobject
    {
    public Response response { get; set; }
    }
    
    public class Response
    {
    public int success { get; set; }
    public int current_time { get; set; }
    public _35 _35 { get; set; }
    public _5002 _5002 { get; set; }
    public _5022 _5022 { get; set; }
    }
    
    public class _35
    {
    public _11 _11 { get; set; }
    public _3 _3 { get; set; }
    }
    
    public class _11
    {
    public _0 _0 { get; set; }
    }
    
    public class _0
    {
    public Current current { get; set; }
    public Previous previous { get; set; }
    }
    
    public class Current
    {
    public string currency { get; set; }
    public int value { get; set; }
    public int value_high { get; set; }
    public int date { get; set; }
    }
    
    public class Previous
    {
    public string currency { get; set; }
    public int value { get; set; }
    public int value_high { get; set; }
    }
    
    public class _3
    {
    public _01 _0 { get; set; }
    }
    
    public class _01
    {
    public Current1 current { get; set; }
    }
    
    public class Current1
    {
    public string currency { get; set; }
    public float value { get; set; }
    public float value_high { get; set; }
    }
    
    public class _5002
    {
    public _6 _6 { get; set; }
    }
    
    public class _6
    {
    public _02 _0 { get; set; }
    }
    
    public class _02
    {
    public Current2 current { get; set; }
    }
    
    public class Current2
    {
    public string currency { get; set; }
    public float value { get; set; }
    public float value_high { get; set; }
    public int date { get; set; }
    }
    
    public class _5022
    {
    public _61 _6 { get; set; }
    }
    
    public class _61
    {
    public _1 _1 { get; set; }
    }
    
    public class _1
    {
    public Current3 current { get; set; }
    }
    
    public class Current3
    {
    public string currency { get; set; }
    public float value { get; set; }
    public float value_high { get; set; }
    public int date { get; set; }
    }
