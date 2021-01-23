    public void Test(object input)
    {
          var res = (dynamic)null;
          if (input.GetType() == typeof(String)))
          {
                res = input.ToString();
                WriteToFile(res);
          }
    }
