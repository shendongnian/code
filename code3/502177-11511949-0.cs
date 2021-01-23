    var output = new StringBuilder();
    for(var index=0; index < wocl.Count; index++)
    {
      var item = wocl[index];
      output.AppendFormat("Frame_X_{0}", index);
    
      for(var index2=0; index2 < item.Point_X.Count; index2++ )
      {
         output.AppendFormat(" {0}", item.Point_X[index2]);
      }
    
      output.AppendFormat("Frame_Y_{0}", index);
    
      for(var index2=0; index2 < item.Point_Y.Count; index2++ )
      {
         output.AppendFormat(" {0}", item.Point_Y[index2]);
      }
    }
    string resultText = output.ToString();
