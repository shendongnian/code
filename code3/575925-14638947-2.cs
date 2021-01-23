    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    
    using LuaInterface;
    
    namespace LuaTest
    	{
    	public class Program
    		{
    		static void Main(string[] args)
    			{
    			Lua lua = new Lua();
    			lua.DoFile("test.lua");
    			}
    
    		public int some_member = 3;
    		}
    
    	public class Pointless
    		{
    		public enum AnEnum
    			{
    			One,
    			Two,
    			Three
    			};
    
    		public static string aStaticInt = "This is static.";
    		public double i;
    		public string n = "Nice";
    		public AnEnum oneEnumVal = AnEnum.One;
    		private AnEnum twoEnumVal = AnEnum.Two;
    		private string very;
    
    		public Pointless(string HowPointLess)
    			{
    			i = 3.13;
    			very = HowPointLess;
    			}
    
    
    
    		public class MoreInnerClass
    			{
    			public string message = "More, please!";
    			}
    
    
    		public void Compare(AnEnum inputEnum)
    			{
    			if (inputEnum == AnEnum.Three)
    				Console.WriteLine("Match.");
    			else
    				Console.WriteLine("Fail match.");
    			}
    		}
    
    
    
    	}
