    namespace System.Numerics
    {
    	/// <summary>Represents an arbitrarily large signed integer.</summary>
    	[Serializable]
    	public struct BigInteger : IFormattable, IComparable, IComparable<BigInteger>, IEquatable<BigInteger>
    	{
        // For values int.MinValue < n <= int.MaxValue, the value is stored in sign
        // and _bits is null. For all other values, sign is +1 or -1 and the bits are in _bits
        internal int _sign;
        internal uint[] _bits;
