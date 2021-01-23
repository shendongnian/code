    public T Get<T>(string pci, int c)
    {
         var a = GetAByPCI(string pci);
    
         if(a == c)
             return new T();
         else
             // throw exception here.
    }
    
