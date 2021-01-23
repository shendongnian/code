    StringBuilder sb = new StringBuilder();
    using(StreamReader rdr = OpenReader(...)) {
        Int32 nc;
        while((nc = rdr.Read()) != -1) {
              Char c = (Char)nc;
              if( c != '\0' ) sb.Append( c );
        }
    }
