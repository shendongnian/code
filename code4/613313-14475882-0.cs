	using System;
	using System.Collections.Generic;
	namespace ConsoleApplication2
	{
		static class Program
		{
			static void Main(string[] args)
			{
				Shuffler shuffler = new Shuffler();
				List<int> list = new List<int>{ 1, 2, 3, 4, 5, 6, 7, 8, 9 };
				shuffler.Shuffle(list);
				foreach (int value in list)
				{
					Console.WriteLine(value);
				}
			}
		}
		/// <summary>Used to shuffle collections.</summary>
		public class Shuffler
		{
			/// <summary>Creates the shuffler with a <see cref="MersenneTwister"/> as the random number generator.</summary>
			public Shuffler()
			{
				_rng = new Random();
			}
			/// <summary>Shuffles the specified array.</summary>
			/// <typeparam name="T">The type of the array elements.</typeparam>
			/// <param name="array">The array to shuffle.</param>
			public void Shuffle<T>(IList<T> array)
			{
				for (int n = array.Count; n > 1; )
				{
					int k = _rng.Next(n);
					--n;
					T temp = array[n];
					array[n] = array[k];
					array[k] = temp;
				}
			}
			private System.Random _rng;
		}
	}
