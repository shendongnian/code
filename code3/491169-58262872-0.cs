    int DefaultSessionId= 0;
    int SessionId= 0;
    int LastStatus = 0;
    string Address = "GPIB0::6" ; //any address
    
    //Session Open
    LastStatus = visa32.viOpenDefaultRM(out DefaultSessionId);
    
    //Connection Open
    LastStatus = visa32.viOpen(DefaultSessionId, Address + "::INSTR", 0, 0, out sessionId);
    LastStatus = visa32.viSetAttribute(SessionId, visa32.VI_ATTR_TERMCHAR, 13);// Set the termination character to carriage return (i.e., 13);
    LastStatus = visa32.viSetAttribute(SessionId, visa32.VI_ATTR_TERMCHAR_EN, 1);// Set the flag to terminate when receiving a termination character
    LastStatus = visa32.viSetAttribute(SessionId, visa32.VI_ATTR_TMO_VALUE, 2000);// Set timeout in milliseconds; set the timeout for your requirements
    
    //Communication
    LastStatus = visa32.viPrintf(SessionId, command + "\n");//device specific commands to write
    StringBuilder message = new StringBuilder(2048);
    LastStatus = visa32.viScanf(SessionId, "%2048t", message);//Readback
    
    //Session and Connection Close
    visa32.viClose(SessionId);
    visa32.viClose(DefaultSessionId);
