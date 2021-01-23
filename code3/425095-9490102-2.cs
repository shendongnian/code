    public static class Extentions
    {
        public static void GoTo ( this TextBox Key , int Line , int Character )
        {
            if ( Line < 1 || Character < 1 || Key . Lines . Length < Line )
                return;
    
            Key . SelectionStart = Key . GetFirstCharIndexFromLine ( Line - 1 ) + Character - 1;
            Key . SelectionLength = 0;
            Key . Focus ( );
        }
    } 
  
