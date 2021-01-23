    public int ParamAsInt
    {
        get 
        { 
            var tmp = default(int);
            if (int.TryParse(param, out tmp))
                return tmp;
            else
                // do something else? throw a specific exception? 
        }
    }
