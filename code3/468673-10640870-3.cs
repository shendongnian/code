    public Dictionary<string, string> Arguments 
    {
      get 
      {
         Dictionary<string, string> vals = new Dictionary<string, string>();
         foreach(KeyValuePair<string, TextBox> kvp in boxes) 
         {
           vals.Add(kvp.Key, kvp.Value.Text);
         }
         
         return vals;
       }
    }
