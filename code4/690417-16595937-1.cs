     public List<int> myNums = new List<int>();
     public void getList(int Num, int Multiplier)
     {
         if (Num != 0)
         {
             myNums.Add((Num % 10)*Multiplier);
             getList(Num / 10,Multiplier* 10);
         }
     }
    
