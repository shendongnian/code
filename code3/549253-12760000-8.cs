	using System;
	using System.Collections.Generic;
	using System.Linq;
	using System.Runtime.InteropServices;
	using System.Runtime.InteropServices.ComTypes;
	class EnumString : IEnumString
	{
		const int E_INVALIDARG = unchecked((int)0x80070057);
		const int S_OK = 0;
		const int S_FALSE = 1;
		int current;
		string[] strings;
		public EnumString(IEnumerable<string> strings)
		{
			this.current = 0;
			this.strings = strings.ToArray();
		}
		public void Clone(out IEnumString ppenum)
		{
			ppenum = new EnumString(strings);
		}
		public int Next(int celt, string[] rgelt, IntPtr pceltFetched)
		{
			if (celt < 0)
				return E_INVALIDARG;
			int num = 0;
			while (current < strings.Length && celt != 0)
			{
				rgelt[num] = strings[current];
				current++;
				num++;
				celt--;
			}
			if (pceltFetched != IntPtr.Zero)
				Marshal.WriteInt32(pceltFetched, num);
			if (celt != 0)
				return S_FALSE;
			return S_OK;
		}
		public void Reset()
		{
			current = 0;
		}
		public int Skip(int celt)
		{
			if (celt < 0)
				return E_INVALIDARG;
			if (strings.Length - current > celt)
			{
				current = strings.Length;
				return S_FALSE;
			}
			current += celt;
			return S_OK;
		}
	}
