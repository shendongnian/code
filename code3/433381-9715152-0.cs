    public List<string> StringParser( string s ){
      var list = new List<string>();
      for( int i = 0; i < s.Length; i++ ){
        if( s[i] == '!' ){
	      list.Add(s.Substring(i,3));
	      i+= 2;
        }
      }
      return list;
    }
