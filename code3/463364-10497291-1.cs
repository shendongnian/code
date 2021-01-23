    using System;
    using System.Collections;
    using System.Runtime.Remoting;
    using System.Runtime.Remoting.Channels;
    using System.Runtime.Remoting.Channels.Tcp;
    using System.IO;
    
    
   
     class Program
     {
	   static void Main(string[] args)
	   {
		AddCounter(5);
		Console.WriteLine(GetCounter());
		AddCounter(3);
		Console.WriteLine(GetCounter());
		AddCounter(7);
		Console.WriteLine(GetCounter());
	  }
	static void AddCounter(int nCounter)
	{
		SetCounter(GetCounter() + nCounter);
	}
	static void SetCounter(int nValue)
	{
		using (FileStream fs = new FileStream("counter.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
		{
			using (BinaryWriter bw = new BinaryWriter(fs))
			{
				bw.Write(nValue);
			}
		}
	}
	static int GetCounter()
	{
		int nRes = 0;
		using (FileStream fs = new FileStream("counter.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite))
		{
			using (BinaryReader br = new BinaryReader(fs))
			{
				if (br.PeekChar() != -1)
				{
					nRes = br.ReadInt32();
				}
			}
		}
		return nRes;
	}
     }
