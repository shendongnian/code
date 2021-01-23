    int length = this.ListBox1.Items.Count;
    	StringBuilder b = new StringBuilder();
    	for ( int i = 0 ; i < length; i++ )
             {
    	  if ( this.ListBox1.Items[ i ] != null && this.ListBox1.Items[ i ].Selected ) 
                  {
    		b.Append( this.ListBox1.Items[ i ].Selected );
    		b.Append( "," );
    	      }
    	 }
    	if ( b.Length > 0 ) 
            {
    	  b.Length = b.Length - 1;
    	}
    	return b.ToString();
