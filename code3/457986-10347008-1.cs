    StringBuilder sb = new StringBuilder();
    //now when accessing the PointCollection 
    foreach(Points aPoints in PointsCollection) 
    { 
       sb.Clear();
       sb.Append(aPoints.Name);
       int length1 = aPoints.Real; 
       int length2 = aPoints.Imag; 
       for(int i = 0 ; i < length1; i++) 
       { 
                sb.AppendFormat("{0},{1} ", aPoints.Real[i], aPoints.Imag[i]); 
       } 
       sb.AppendLine(); 
       stream.Write(sb.ToString()); 
    } 
