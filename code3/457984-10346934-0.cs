    foreach(Points aPoints in PointsCollection) 
    {
       stream.Write(aPoints.Name)
       foreach (var complexNumber in aPoints.Real.Zip(aPoints.Imag,
           (real, imag) => new { Real = real, Imag = imag }))
       {
            stream.Write(complexNumber.Real);
            stream.Write(",");
            stream.Write(complexNumber.Imag);
       }
       stream.WriteLine();
    }
