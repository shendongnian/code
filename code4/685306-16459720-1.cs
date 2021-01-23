	static public class BitSetExtensions
	{
		/// <summary>
		/// Treats the bits as a number (like Int32) and increases it with one.
		/// </summary>
		static public void Increase(this BitArray bits)
		{
			for (int i = 0; i < bits.Length; i++)
			{
				if (!bits[i])
				{
					bits[i] = true;
					bits.SetAll(0, i - 1, false);
					return;
				}
				bits[i] = false;
			}
			bits.SetAll(false);
		}
		/// <summary>
		/// Sets the subset of bits from the start position till length with the given value.
		/// </summary>
		static public void SetAll(this BitArray bits, int start, int length, bool value)
		{
			while(length-- > 0)
				bits[start++] = value;
		}
		/// <summary>
		/// Returns true if all bits in the collection are false.
		/// </summary>
		static public bool IsEmpty(this BitArray bits)
		{
			for (int i = 0; i < bits.Length; i++)
				if (bits[i])
					return false;
			return true;
		}
	}
