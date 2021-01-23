    string xml = @"
    <Data>
    <Server>
      <ConnectionsCurrent>67</ConnectionsCurrent> 
      <ConnectionsTotal>1424182</ConnectionsTotal> 
      <ConnectionsTotalAccepted>1385091</ConnectionsTotalAccepted> 
      <ConnectionsTotalRejected>39091</ConnectionsTotalRejected> 
      <MessagesInBytesRate>410455.0</MessagesInBytesRate> 
      <MessagesOutBytesRate>540146.0</MessagesOutBytesRate> 
     </Server>
     <VHost>
      <Name>_defaultVHost_</Name> 
      <TimeRunning>5129615.178</TimeRunning> 
      <ConnectionsLimit>0</ConnectionsLimit> 
      <ConnectionsCurrent>67</ConnectionsCurrent> 
      <ConnectionsTotal>1424182</ConnectionsTotal> 
      <ConnectionsTotalAccepted>1385091</ConnectionsTotalAccepted> 
      <ConnectionsTotalRejected>39091</ConnectionsTotalRejected> 
      <MessagesInBytesRate>410455.0</MessagesInBytesRate> 
      <MessagesOutBytesRate>540146.0</MessagesOutBytesRate> 
     </VHost>
     <Application>
      <Name>TestApp</Name> 
      <Status>loaded</Status> 
      <TimeRunning>411642.953</TimeRunning> 
      <ConnectionsCurrent>11</ConnectionsCurrent> 
      <ConnectionsTotal>43777</ConnectionsTotal> 
      <ConnectionsTotalAccepted>43135</ConnectionsTotalAccepted> 
      <ConnectionsTotalRejected>642</ConnectionsTotalRejected> 
      <MessagesInBytesRate>27876.0</MessagesInBytesRate> 
      <MessagesOutBytesRate>175053.0</MessagesOutBytesRate></Application>
      </Data>";
      
      
      var XDoc = XDocument.Parse(xml);
      
      XDoc.Descendants("VHost")
    	  .Descendants("ConnectionsTotal")
    	  .Select (ele => ele.Value )
    	  .Dump();  
          
