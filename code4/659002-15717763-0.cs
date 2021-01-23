	using System;
	using System.Threading;
	namespace Demo
	{
		internal class Program
		{
			private static void Main(string[] args)
			{
				var melody = new Melody { Value = 1 };
				var wrapper = new MelodyWrapper { Melody = melody };
				Thread melodyThread = new Thread(() => PlayMelody(wrapper));
				melodyThread.Start();
				melodyThread.Join();
				Console.WriteLine(wrapper.Melody.Value);
			}
			private static void PlayMelody(MelodyWrapper wrapper)
			{
				Console.WriteLine(wrapper.Melody.Value);
				Thread.Sleep(1000);
				wrapper.Melody.Value = 2;
			}
		}
		public struct Melody
		{
			public int Value;
		}
		public class MelodyWrapper
		{
			public Melody Melody;
		}
	}
