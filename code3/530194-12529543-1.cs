    using System;
    using System.Collections.Concurrent;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using MyLogType;
    namespace MyHelper
    {
	/// <summary>
	/// NOTE: Non thread safe, only run this individually.
	/// </summary>
	/// <typeparam name="T">Type of item we are adding to the dictionary.</typeparam>
	public class MyIntegerKeyDictionary<T> where T : class
	{
		/// <summary>
		/// Array in which we store the entries.
		/// </summary>
		volatile private T[] ArrayToUse;
		/// <summary>
		/// Allows us to check the maximum size, just in case.
		/// </summary>
		private readonly int SizeInternal;
		/// <summary>
		/// Keeps track of the current number of items in the dictionary.
		/// </summary>
		public int Count = 0;
		/// <summary>
		/// Base number. For numbers that start with a huge base, this allows the index to work without allocating megabytes of memory.
		/// </summary>
		private int BaseNumberToAdd { get; set; }
		/// <summary>
		/// Constructor.
		/// </summary>
		/// <param name="Size">Size of the dictionary.</param>
		public MyIntegerKeyDictionary(int Size)
		{
			// Create the array to hold n number of items.
			ArrayToUse = new T[Size];
			// We must touch all of these entries, to force page faults now (rather than later).
			for (int i = 0; i < ArrayToUse.Length; i++)
			{
				ArrayToUse[i] = null;
			}
			BaseNumberToAdd = int.MinValue;
			this.SizeInternal = Size;
		}
		/// <summary>
		/// Add an item.
		/// </summary>
		/// <param name="Key">Key.</param>
		/// <param name="Value">Value.</param>
		/// <returns>True if the item was added, false if not.</returns>
		public bool TryAdd(int Key, T Value)
		{
			if (BaseNumberToAdd == int.MinValue)
			{
				BaseNumberToAdd = Key;
				//Console.Write(string.Format("{0}Message W20120907-3751. TryAdd. Adding first item {1}.\n",
				//MyLog.NPrefix(), Key));
			}
			Key = Key - BaseNumberToAdd;
			if (Key < 0)
			{
				Console.Write(string.Format("{0}Warning W20120907-3750. TryAdd. Attempted to add a key with index {1} which is < 0.\n",
					MyLog.NPrefix(), Key));
				return false;
			}
			if (Key >= this.SizeInternal)
			{
				Console.Write(string.Format("{0}Warning W20120907-3756. TryAdd. Attempted to add a key with index {1} which is > max {2}\n",
					MyLog.NPrefix(), Key, this.SizeInternal));
				return false;
			}
			if (ArrayToUse[Key] == null)
			{
				Interlocked.Increment(ref Count);
			}
			ArrayToUse[Key] = Value;
			return true;
		}
		/// <summary>
		/// Remove an item from the dictionary.
		/// </summary>
		/// <param name="Key">Key that we want to remove.</param>
		/// <returns>True if the item could be removed, false if not.</returns>
		public bool TryRemove(int Key)
		{
			if (BaseNumberToAdd == int.MinValue)
			{
				Console.Write(string.Format("{0}Warning W20120907-8756. TryRemove. Attempted to remove an item without any items in the dictionary yet {1}.\n",
					MyLog.NPrefix(), Key));
				return false;
			}
			Key = Key - BaseNumberToAdd;
			if (Key < 0)
			{
				Console.Write(string.Format("{0}Warning W20120907-9756. TryRemove. Attempted to remove a key with index {1} which is < 0.\n",
					MyLog.NPrefix(), Key));
				return false;
			}
			if (Key >= this.SizeInternal)
			{
				Console.Write(string.Format("{0}Warning W20120907-6756. TryRemove. Attempted to remove a key with index {1} which is > max {2}\n",
					MyLog.NPrefix(), Key, this.SizeInternal));
				return false;
			}
			if (ArrayToUse[Key] != null)
			{
				Interlocked.Decrement(ref Count);
			}
			ArrayToUse[Key] = null;
			return true;
		}
		/// <summary>
		/// Indexer.
		/// </summary>
		/// <param name="key">Key.</param>
		/// <returns>Value.</returns>
		public T this[int key]
		{
			get
			{
				T valueToReturn;
				TryGetValue(key, out valueToReturn);
				return valueToReturn;
			}
		}
		/// <summary>
		/// Attempt to get the value.
		/// </summary>
		/// <param name="Key">Key.</param>
		/// <param name="Value">Value.</param>
		/// <returns>True if the value exists, false if not.</returns>
		public bool TryGetValue(int Key, out T Value)
		{
			Value = null;
			if (BaseNumberToAdd == int.MinValue)
			{
				Console.Write(string.Format("{0}Warning W20120907-8756. TryGetValue. Attempted to retrieve an item without any items in the dictionary yet {1}.\n",
					MyLog.NPrefix(), Key));
				return false;
			}
			Key = Key - BaseNumberToAdd;
			if (ArrayToUse[Key] == null)
			{
				return false;
			}
			Value = ArrayToUse[Key];
			return true;
		}
		/// <summary>
		/// Checks to see if the key exists.
		/// </summary>
		/// <param name="Key">Key index.</param>
		/// <returns>True if the item exists, false if not.</returns>
		public bool ContainsKey(int Key)
		{
			if (Key == 0)
			{
				Console.Write(string.Format("{0}Warning W20120907-1914. ContainsKey. Have not rebased yet. Ignoring query for ContainsKey(0).\n",
					MyLog.NPrefix()));
				return false;
			}
			if (BaseNumberToAdd == int.MinValue)
			{
				Console.Write(string.Format("{0}Warning W20120907-8756. ContainsKey. Attempted to check if Key {1} exists, however BaseNumber is not set yet.\n",
					"", Key));
				return false;
			}
			Key = Key - BaseNumberToAdd;
			if (Key < 0)
			{
				Console.Write(string.Format("{0}Warning W20120907-8756. ContainsKey. Key = {1} which is < 0.\n",
					"", Key));
				return false;
			}
			if (Key >= this.SizeInternal)
			{
				MyLogAsync.LogWarning(string.Format("{0}Warning W20120907-5756. ContainsKey. Key({1}) >= this.SizeInternal ({2}).\n",
					MyLog.NPrefix(), Key, this.SizeInternal));
				return false;
			}
			if (ArrayToUse[Key] == null)
			{
				return false;
			}
			return true;
		}
		/*
		private bool CheckKeyBounds(int Key, string description)
		{
			if (Key < 0)
			{
				MyLogAsync.LogWarning(string.Format("{0}Warning W20120907-8756. {1}. Attempted to add a key with index {2} which is < 0.\n",
					MyLog.NPrefix(), description, Key));
			}
			if (Key >= this.SizeInternal)
			{
				MyLogAsync.LogWarning(string.Format("{0}Warning W20120907-5756. {1}. Attempted to add a key with index {2} which is > max {3}\n",
					MyLog.NPrefix(), description, Key, this.SizeInternal));
				return false;
			}
		}
		*/
	}
    }
