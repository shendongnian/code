    if(B.Count != A.Count)
        return;
    List<String> reserved = new List<string>{ "ARCB", "ARINC" };
            
     for (int i = A.Count -1; i >= 0; i--)
     {
         if (!reserved.Contains(A[i].ToUpper()) && A[i] == B[i])
         {
             A.RemoveAt(i);
             B.RemoveAt(i);
         }
     }
