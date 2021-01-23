    var ListofOrgans = List<Organ>(); 
    String tmp = null;
    String [] tokens = null;
    using(StreamReader sr = new StreamReader(@"C:\Parameter.csv"))
    {
       while( !sr.EndOfStream )
       {
          tmp = sr.ReadLine();
          tokens = tmp.Split(' ');
          Organ foo = new Organ();
          foo.name = tokens[0];
          foo.A = Convert.ToDouble(tokens[1]);
          .
          .
          etc.
          ListOfOrgans.Add(foo);
       }
    }
