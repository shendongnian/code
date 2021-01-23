    var collection = System.Web.HttpUtility.ParseQueryString("10=on&13=on&15=on");
    	
    foreach (var key in collection.Keys.Cast<string>())
    {
        int i;
        if (int.TryParse(key, out i))
        {
            // add i to list of ints
        }
    }
