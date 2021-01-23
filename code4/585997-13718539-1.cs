    Public Const ESC = Chr(&H1B) + "|" ;
            Public Const SetBold = ESC+ "bC";
            Public Const SetUnderline = ESC + "uC";
            Public Const SetItalic = ESC +"iC" ;
            Public Const SetCentre = ESC + "cA" ;
            Public Const SetRight = ESC + "rA" ;
            Public Const ResetFormatting = ESC + "N" ;
    
     String msg = "This is a test" + "\r\n"+ SetBold + SetSize(3)+ SetCentre + "it works" +SetSize(1) + " pretty well" + "\r\n" + "OK" ;
