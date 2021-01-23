    using System;
    using System.Text;
    using System.Security.Cryptography;
    
    namespace TDESMacExample
    {
    	class MainClass
    	{
    		public static void Main (string[] args)
    		{
    			var keyString = "012345678901234567890123";
    			var keyBytes = Encoding.ASCII.GetBytes(keyString);
    			var mac = new MACTripleDES(keyBytes);
    			var data = "please authenticate me example number one oh one point seven niner";
    			Console.WriteLine(data.Length);
    			var macResult = mac.ComputeHash(Encoding.ASCII.GetBytes(data));
    			Console.WriteLine(BitConverter.ToString(macResult));
    			// B1-29-14-74-EA-E2-74-2D
    		}
    	}
    }
