    [HttpPost]
    [ActionName("TestString")]
    public string TestString([FromBody] dynamic body)
    {
      return "test " + body.a.ToString() + " " + body.b.ToString() + " " + body.c.ToString();
    }
