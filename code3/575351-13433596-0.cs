     for (int i = 0; i < k.Length + q.Length; i++)
     {
         if (i < k.Length) {
             Items.SubItems.Add(input + k[i]);
         } else {
             Items.SubItems.Add(input + q[i - k.Length]);
         }
     }
