    public static string ConvertToXmlCharacterReference( this string xml )
    {
      StringBuilder sb  = new StringBuilder( s.Length ) ;
      const char    SP  = '\u0020' ; // anything lower than SP is a control character
      const char    DEL = '\u007F' ; // anything above DEL isn't ASCII, per se.
      foreach( char ch in xml )
      {
        bool isPrintableAscii = ch >= SP && ch <= DEL ;
        
        if ( isPrintableAscii ) { sb.Append(ch)                             ; }
        else                    { sb.AppendFormat( "&#x{0:X4}" , (int) ch ) ; }
        
      }
      
      string instance = sb.ToString() ;
      return instance ;
    }
