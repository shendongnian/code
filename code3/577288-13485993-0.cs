    public async void DoAsync()
    {
          await Task.Run( () =>
          { 
             // Do task! 
          } );
    }
    
    public async Task<string> GetStringAsync()
    {
           string s = "";
           await Task.Run( () =>
           {
                for(int I = 0; I < 9999999; I++)
                {
                       s += I.ToString();
                }
           }
           return s;
    }
