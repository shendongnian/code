    using Microsoft.QualityTools.Testing.Fakes;
    ...
    using (ShimsContext.Create())
    {
         System.IO.Fakes.ShimDirectory.ExistsString = (p) => true;
         System.IO.Fakes.ShimFile.MoveStringString = (p,n) => {};
         // .. and other methods you'd like to test
         var result = RestoreExtension("C:\myfile.ext");
         // then you can assert with this result 
    }
