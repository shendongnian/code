    void Main()
    {
      string ingredients =
    @"500g Flour
    0.5g Salt
    7g Dry yeast
    45ml Olive oil
    309ml Water";
      string pattern = @"(?:[0-9]+\.?[0-9]*|\.[0-9]+)";
      
      int multiple = 2;
	
      Regex.Replace(ingredients, pattern, m => (Convert.ToDecimal(m.Value)*multiple).ToString()).Dump();
    }
