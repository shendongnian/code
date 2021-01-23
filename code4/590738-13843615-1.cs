    StringBuilder sb = new StringBuilder("bla Bla: ");
    
    sb.Append( Sig ).Append( " bla bla " ).Append( string.Join(", ", usedCnt.toCntName()) );
    if (refCnts.Count() != 0)
    {
    
        sb.Append( "some Text" );
    }
    else 
    {
        sb.Append( " some other Text" );
    }
    
    //lineToSend = "dummyStringLine";
    messageObj.setMessageLines(sb.ToString());
