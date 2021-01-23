	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Collections;
	namespace TestStack
	{
		class EvilEnumerator<T> : IEnumerator<T> {
			private IEnumerable<T> enumerable;
			private int index = -1;
			public EvilEnumerator(IEnumerable<T> e) 
			{
				enumerable = e;
			}
			#region IEnumerator<T> Membres
			public T Current
			{
				get { return enumerable.ElementAt(index); }
			}
			#endregion
			#region IDisposable Membres
			public void Dispose()
			{
				
			}
			#endregion
			#region IEnumerator Membres
			object IEnumerator.Current
			{
				get { return enumerable.ElementAt(index); }
			}
			public bool MoveNext()
			{
				index++;
				if (index >= enumerable.Count())
					return false;
				return true;
			}
			public void Reset()
			{
				
			}
			#endregion
		}
		class DemoEnumerable<T> : IEnumerable<T>
		{
			private IEnumerable<T> enumerable;
			public DemoEnumerable(IEnumerable<T> e)
			{
				enumerable = e; 
			}
			#region IEnumerable<T> Membres
			public IEnumerator<T> GetEnumerator()
			{
				return new EvilEnumerator<T>(enumerable);
			}
			#endregion
			#region IEnumerable Membres
			IEnumerator IEnumerable.GetEnumerator()
			{
				return this.GetEnumerator();
			}
			#endregion
		}
		class Program
		{
			static void Main(string[] args)
			{
				IEnumerable<int> numbers = Enumerable.Range(0,100);
				DemoEnumerable<int> enumerable = new DemoEnumerable<int>(numbers);
				foreach (var item in enumerable)
				{
					Console.WriteLine(item);
				}
			}
		}
	}
