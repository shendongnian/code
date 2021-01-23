    StringBuilder sb = new StringBuilder();
    //now when accessing the PointCollection 
    foreach(Points aPoints in PointsCollection) 
    { 
       sb.Clear();
       sb.Append(aPoints.Name);
       int length1 = aPoints.Real.Lenght;  // Get the length of Real array
       // int length2 = aPoints.Imag; // Not needed???
       for(int i = 0 ; i < length1; i++) 
       { 
            sb.AppendFormat("{0},{1} ", aPoints.Real[i], aPoints.Imag[i]); 
       } 
       sb.AppendLine(); 
       stream.Write(sb.ToString()); 
    } 
