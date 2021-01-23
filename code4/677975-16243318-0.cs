    static Dictionary<string,int> Slurp( string rootDirectory )
    {
      Dictionary<string,int> instance = Directory.EnumerateFiles(rootDirectory,"*.log",SearchOption.TopDirectoryOnly)
                                                 .SelectMany( fn => File.ReadAllLines(fn)
                                                                        .Skip(4)
                                                                        .Select( txt => txt.Split( " ".ToCharArray() , StringSplitOptions.RemoveEmptyEntries) )
                                                                        .Where(x => x.Length > 9 )
                                                                        .Select( x => x[9])
                                                            )
                                                 .GroupBy( x => x )
                                                 .ToDictionary( x => x.Key , x => x.Count()) 
                                                 ;
      return instance ;
    }
 
