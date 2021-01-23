    using System;
    using System.Collections.Generic;
    using System.Linq;
    static class LinqExtensions
    {
    	public static IEnumerable<T> EveryNth<T>(this IEnumerable<T> e, int start, int n)
    	{
    		int index = 0;
    		foreach(T t in e)
    		{
    			if((index - start) % n == 0)
    			{
    				yield return t;
    			}
    			++index;
    		}
    	}
    }
    class Program
    {
    	static void Main(string[] args)
    	{
    		List<byte> byteList = new List<byte>()
    		{
    			0x01, 0x09, 0x01, 0x02, 0x08, 0x02, 0x03, 0x07, 0x03
    		};
    		var completeObjects =
    			byteList.EveryNth(0, 3).Zip
    			(
    				byteList.EveryNth(1, 3).Zip
    				(
    					byteList.EveryNth(2, 3),
    					Tuple.Create
    				),
    				(f,t) => new { Address = f, OldValue = t.Item1, NewValue = t.Item2 }
    			);
    		foreach (var anonType in completeObjects)
    		{
    			Console.WriteLine("Address: {0}\nOld Value: {1}\nNew Value: {2}\n", anonType.Address, anonType.OldValue, anonType.NewValue);
    		}
    	}
    }
