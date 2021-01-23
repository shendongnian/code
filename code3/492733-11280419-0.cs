        static void Main(string[] args)
        {
          string line;
          List<Package> packages = new List<Package>();
          Package package = null;
          StreamReader file = new System.IO.StreamReader("TextFile1.txt");
          while ((line = file.ReadLine()) != null)
          {
            string[] pair = line.Split(new string[] { ": " }, StringSplitOptions.None);
            if (pair.Length != 2)
              continue;
            if (pair[0] == "Package")
            {
              package = new Package();
              packages.Add(package);
            }
            package.Values.Add(pair[0].Trim(), pair[1].Trim());
          }
          file.Close();
          Console.WriteLine(packages.Count);
          foreach (Package p in packages)
          {
            Console.WriteLine(p);
            foreach (KeyValuePair<string, string> pair in p.Values)
              Console.WriteLine("{0}={1}", pair.Key, pair.Value);
          }
          Console.ReadLine();
        }
      }
    
      class Package
      {
        public Dictionary<string, string> Values;
        public Package()
        {
          Values = new Dictionary<string, string>();
        }
      }
