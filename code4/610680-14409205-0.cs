     int My.ReadProcessMemory(T1 a1, T2 a2, T3 variable)
     {...}
     class ReadProcessMemory
     {
          T1 a1;
          T2 a2;
          public ReadProcessMemory(T1 a1, T2 a2)
          {
             this.a1 = a1;
             this.a2 = a2;
          }
          public int Run(T3 variable)
          {
             return My.ReadProcessMemory(a1, a2, variable);
          }
     }
