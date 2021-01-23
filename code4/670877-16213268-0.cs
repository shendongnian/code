    public IEnumerable<IEnumerable<T>> GetPortions<T>(IEnumerable<T> list, int portion)
    {
       double length = (list.Count() / (double)portion); 
    
       for (int i = 0; i < length; i++)
       {
             yield return list.ToList().Skip(i * portion).Take(portion);
       } 
    }
    
    protected void Page_Load(object sender, EventArgs e)
    { 
        IEnumerable<int> list = Enumerable.Range(1, 25); 
        
        foreach (var item in GetPortions(list, 10))
        {
           
        }
     }
