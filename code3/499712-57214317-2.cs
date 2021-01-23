    using System;
    using System.Security.Cryptography.X509Certificates;
    
    public class X509
    {
    
        public static void Main()
        {
            // The paths to the certificate signed files
            string Certificate =  @"Signed1.exe";
            string OtherCertificate = @"Signed2.exe";
    
            // Starting with .NET Framework 4.6, the X509Certificate type implements the IDisposable interface...
            using (X509Certificate certOne = X509Certificate.CreateFromCertFile(Certificate))
            using (X509Certificate certTwo = X509Certificate.CreateFromCertFile(OtherCertificate))
    		{
    	        bool result = certOne.Equals(certTwo);
           
            	Console.WriteLine(result);
    		}
        }
    
    }
 
