    StringBuilder sb = new StringBuilder();
    
    sb.AppendLine("Zusammenfassung:").AppendLine( text0 ).AppendLine( text1 ).AppendLine( Environment.NewLine );
    sb.AppendLine( text2 );
    sb.Append( text3 ).Append( Environment.NewLine );
    //I'm sure you get the idea here
    
    oItem.Body = sb.ToString();
