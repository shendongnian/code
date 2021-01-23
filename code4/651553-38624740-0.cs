    Mainpipe df; 
    Package pkg;
    foreach (IDTSComponentMetaData100 comp in df.ComponentMetaDataCollection)
    {
      if ((comp.ObjectType & DTSObjectType.OT_SOURCEADAPTER ) == DTSObjectType.OT_SOURCEADAPTER )
      {
        foreach (IDTSCustomProperty100 cp in comp.CustomPropertyCollection)
        {
           Debug.WriteLine(string.Format("{0} - {1}",cp.Name,cp.Value));
        }
        if (comp.RuntimeConnectionCollection.Count > 0)
        {
          IDTSRuntimeConnection100 rtconn = comp.RuntimeConnectionCollection[0];
          if (pkg.Connections.Contains(rtconn.ConnectionManagerID))
          {
            var conn = Package.Connections[rtconn.ConnectionManagerID];
            // Get the connection name
            varconnName = conn.Name;
          }
       }
     }
                        
