    SendCommand(char * bfr)
    {
    }
    
    RecieveCommand(char * bfr)
    {
    }
    SendCommand( txBfr );
    RecieveData( rxBfr );
    // process receive buffer, prepare new command
    SendCommand( txbfr );
    RecieveCommand( rxBfr );
    // and so on
