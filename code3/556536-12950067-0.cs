    public int Sum(params int[] customerssalary)
    {
       int result = 0;
    
       for(int i = 0; i < customerssalary.Length; i++)
       {
          result += customerssalary[i];
       }
    
       return result;
    }
