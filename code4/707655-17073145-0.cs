    private void pressG()
    {
       AutoItX3Declarations.AU3_Send("{g down}", 0);
       AutoItX3Declarations.AU3_Sleep( 50 );          //wait 50 milliseconds
       AutoItX3Declarations.AU3_Send("{g up}", 0);
    }
