    class MyResponse
    {
        int Result {get; set;}
        List<int> Ids {get; set;}
    
        public MyResponse() 
        {
            Result = 0;
            Ids = new List<int>();
        }
    }
