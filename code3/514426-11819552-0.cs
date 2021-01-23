    namespace System.Numerics
    {
    	/// <summary>Represents an arbitrarily large signed integer.</summary>
    	[Serializable]
    	public struct BigInteger : IFormattable, IComparable, IComparable<BigInteger>, IEquatable<BigInteger>
    	{
    		internal int _sign;
    		internal uint[] _bits;
            //Snip
