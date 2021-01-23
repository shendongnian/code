    public class MyPoco{
        public int a;
        public int b;
    }
    //send {"a":1, "b":2} in body to me
    [HttpPost("api2")]
    public String PostMethod2([FromBody]MyPoco value)
    {
        return "received " + value.ToString();  //"received your_namespace+MyPoco"
    }
