    IDictionary<int, int> map = new Dictionary<int, int>();
    map.Add(1, 10);
    map.Add(3, 20);
    
    
    public int GetResponseForUserInput(int input)
    {
       int response = -1;
       if (map.ContainsKey(input))
       {
          response = map[input];
       }
    
       return response;
    }
