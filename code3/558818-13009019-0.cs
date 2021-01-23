    void Print100(int n)
    {
       if (n >= 100)
       {
           Console.WriteLine();  // cosmetic
           return;               // stop recursing
       }
    
       Console.WriteLine(n);   // 1-100
       Print100(n+1);
       Console.WriteLine(n);   // 100-1
    }
