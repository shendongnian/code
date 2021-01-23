    public bool Validate(List<string> parameters)
    {
       foreach(string parameter in parameters)
       {
            if(String.IsNullOrEmpty(parameter))
            {
                return false;
            }
       }
       return true;
    }
