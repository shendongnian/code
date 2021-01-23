     public static void WriteToCvs<T>(this T[,] array, string fileName)
     {
         using (var stream = File.CreateText(fileName))
         {
             for (int i = 0; i < array.GetLength(0); i++)
             {
                 var values = new List<T>();
                 for (int j = 0; j < array.GetLength(1); j++)
                 {
                     values.Add(array[i, j]);
                 }
                 stream.WriteLine(string.Join(",", values));
             }
         }
     }
