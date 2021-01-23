    string test = "\"MIKE YANICK\",\"412 A AVE \"E\",\" \",\"NADIEN PA\",\" \",\"190445468\"";
    string[] fields = test.Split(new char[] {','});
    StringBuilder result = new StringBuilder();
    bool first = true;
    
    foreach (var field in fields)
    {
        if(first)
        {
            first = false;
        }
        else
        {
                result.Append(",");
        }
    
        result.AppendFormat("\"{0}\"", field.Replace("\"",""));
    }
                
    Console.WriteLine (string.Format("Old : {0} New: {1}", test,result.ToString()));
                
