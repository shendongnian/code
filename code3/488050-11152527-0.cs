    static void Main(string[] args) 
    { 
      Dictionary<string, int> dic = new Dictionary<string, int>(); 
 
      lock(dic)
      {
       dic.Add("Kej1",0); 
       dic.Add("Kej2",1); 
       dic.Add("Kej3", 3); 
       dic.Add("Kej4", 3); 
 
       String[] arr = new string[dic.Count] ; 
       dic.Keys.CopyTo(arr,0);
 
       foreach (var va in arr) 
       { 
         Console.WriteLine(dic[va] + " " + va); 
         dic[va] = 10; 
         Console.WriteLine(dic[va] + " " + va); 
       } 
      } 
      Console.ReadKey(); 
    } 
