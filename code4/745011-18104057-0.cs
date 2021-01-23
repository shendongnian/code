       Try this: 
      string line = "1/5";
      int idx = line.IndexOf('/');
      Console.WriteLine(idx);
      int a = Int32.Parse(line.Substring(0, idx));
      Console.WriteLine(a);
      
      int b = Int32.Parse(line.Substring(idx+1, line.Length - (idx+1)));
      Console.WriteLine(b);
      decimal result = a/b;
            
                Console.WriteLine(result);
