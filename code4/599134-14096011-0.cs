    using System;
    using System.Security.Cryptography;
    using System.Text;
    
    namespace Hash8096
    {
    	class MainClass
    	{
    		public static byte [] H8096(byte [] x) {
    			byte [] Result = new byte[8096 / 8];
    			byte [] Xplus1 = new byte[x.Length + 1];
    			x.CopyTo(Xplus1, 1);
    			int ResultOffset = 0;
    			int AmountLeft = Result.Length;
    			for (int i=0; i<64; i++) {
    				// do MD5(i || x)
    				var md5 = MD5.Create();
    				Xplus1[0] = (byte) i;
    				var hash = md5.ComputeHash(Xplus1);
    				int NumToCopy = Math.Min(hash.Length, AmountLeft);
    				Array.Copy(hash, 0, Result, ResultOffset,NumToCopy);
    				ResultOffset += NumToCopy;
    				AmountLeft -= NumToCopy;
    			}
    			return Result;
    		}
    
    		public static void Main (string[] args)
    		{
    			byte [] x = Encoding.UTF8.GetBytes("Hello World!");
    			byte [] MonsterHash = H8096(x);
    			Console.WriteLine ("Monster hash in hex follows:");
    			Console.WriteLine(BitConverter.ToString(MonsterHash));
    		}
    	}
    }
