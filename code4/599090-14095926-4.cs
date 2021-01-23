    using System;
    using System.Security.Cryptography;
    
    namespace DsaParametersToy
    {
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			var dsa = new DSACryptoServiceProvider(1024);
    			var dsaparams = dsa.ToXmlString(false);
    			Console.WriteLine (dsaparams);
    		}
    	}
    }
