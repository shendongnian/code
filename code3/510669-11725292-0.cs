    [HttpGet]
    public String Active(int id = 0)
    {
        var result = new List<string> { "active1", "active2" };
        
        if (id == 0) {
          return result;
        } else {
          return result[id];
        }
    }
