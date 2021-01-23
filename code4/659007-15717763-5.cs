	using System;
	using System.Threading;
	namespace Demo
	{
		internal class Program
		{
			private static void Main(string[] args)
			{
				var melody = new Melody { Value = 1 };
				Func<Melody, Melody> play = PlayMelody;
				var result = play.BeginInvoke(melody, null, null);
				melody = play.EndInvoke(result);
				Console.WriteLine(melody.Value);
			}
			private static Melody PlayMelody(Melody melody)
			{
				Console.WriteLine(melody.Value);
				Thread.Sleep(1000);
				melody.Value = 2;
				return melody;
			}
		}
		public struct Melody
		{
			public int Value;
		}
	}
