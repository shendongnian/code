    namespace Utils
    {
    	using System;
    	using System.Collections;
    	using System.Collections.Generic;
    	using System.ComponentModel;
    	using System.Globalization;
    	using System.Linq;
    	using System.Threading;
    
    	/// <summary>
    	/// A replacement for BitArray
    	/// </summary>
    	public class BoolArray : IEnumerable, ICollection, ICloneable
    	{
    		private UInt32[] bits = null;
    		private int _length = 0;
    		private static UInt32 ONE = (UInt32)1 << 31;
    		private object _syncRoot;
    		private static Func<byte[], byte[]> EndianFixer = null;
    
    		#region Constructors
    
    		static BoolArray()
    		{
    			if (BitConverter.IsLittleEndian) EndianFixer = (a) => a.Reverse().ToArray();
    			else EndianFixer = (a) => a;
    		}
    
    		public BoolArray(BoolArray srcBits)
    		{
    			this.InitializeFrom(srcBits.ToArray());
    		}
    
    		public BoolArray(BitArray srcBits)
    		{
    			this._length = srcBits.Count;
    			this.bits = new UInt32[RequiredSize(this._length)];
    
    			for (int i = 0; i < srcBits.Count; i++) this[i] = srcBits[i];
    		}
    
    		public BoolArray(int v)
    		{
    			ICollection<byte> bytes = EndianFixer(BitConverter.GetBytes(v)).ToList();
    			InitializeFrom(bytes);
    		}
    
    		public BoolArray(ICollection<bool> srcBits)
    		{
    			this.InitializeFrom(srcBits.ToArray());
    		}
    
    		public BoolArray(ICollection<byte> srcBits)
    		{
    			InitializeFrom(srcBits);
    		}
    
    		public BoolArray(ICollection<short> srcBits)
    		{
    			ICollection<byte> bytes = srcBits.SelectMany(v => EndianFixer(BitConverter.GetBytes(v))).ToList();
    			InitializeFrom(bytes);
    		}
    
    		public BoolArray(ICollection<ushort> srcBits)
    		{
    			ICollection<byte> bytes = srcBits.SelectMany(v => EndianFixer(BitConverter.GetBytes(v))).ToList();
    			InitializeFrom(bytes);
    		}
    
    		public BoolArray(ICollection<int> srcBits)
    		{
    			ICollection<byte> bytes = srcBits.SelectMany(v => EndianFixer(BitConverter.GetBytes(v))).ToList();
    			InitializeFrom(bytes);
    		}
    
    		public BoolArray(ICollection<uint> srcBits)
    		{
    			ICollection<byte> bytes = srcBits.SelectMany(v => EndianFixer(BitConverter.GetBytes(v))).ToList();
    			InitializeFrom(bytes);
    		}
    
    		public BoolArray(ICollection<long> srcBits)
    		{
    			ICollection<byte> bytes = srcBits.SelectMany(v => EndianFixer(BitConverter.GetBytes(v))).ToList();
    			InitializeFrom(bytes);
    		}
    
    		public BoolArray(ICollection<ulong> srcBits)
    		{
    			ICollection<byte> bytes = srcBits.SelectMany(v => EndianFixer(BitConverter.GetBytes(v))).ToList();
    			InitializeFrom(bytes);
    		}
    
    		public BoolArray(int capacity, bool defaultValue = false)
    		{
    			this.bits = new UInt32[RequiredSize(capacity)];
    			this._length = capacity;
    
    			// Only need to do this if true, because default for all bits is false
    			if (defaultValue) for (int i = 0; i < this._length; i++) this[i] = true;
    		}
    
    		private void InitializeFrom(ICollection<byte> srcBits)
    		{
    			this._length = srcBits.Count * 8;
    			this.bits = new UInt32[RequiredSize(this._length)];
    			for (int i = 0; i < srcBits.Count; i++)
    			{
    				uint bv = srcBits.Skip(i).Take(1).Single();
    				for (int b = 0; b < 8; b++)
    				{
    					bool bitVal = ((bv << b) & 0x0080) != 0;
    					int bi = 8 * i + b;
    					this[bi] = bitVal;
    				}
    			}
    		}
    
    		private void InitializeFrom(ICollection<bool> srcBits)
    		{
    			this._length = srcBits.Count;
    			this.bits = new UInt32[RequiredSize(this._length)];
    
    			int index = 0;
    			foreach (var b in srcBits) this[index++] = b;
    		}
    
    		private static int RequiredSize(int bitCapacity)
    		{
    			return (bitCapacity + 31) >> 5;
    		}
    
    		#endregion
    
    		public bool this[int index]
    		{
    			get
    			{
    				if (index >= _length) throw new IndexOutOfRangeException();
    
    				int byteIndex = index >> 5;
    				int bitIndex = index & 0x1f;
    				return ((bits[byteIndex] << bitIndex) & ONE) != 0;
    			}
    			set
    			{
    				if (index >= _length) throw new IndexOutOfRangeException();
    
    				int byteIndex = index >> 5;
    				int bitIndex = index & 0x1f;
    				if (value) bits[byteIndex] |= (ONE >> bitIndex);
    				else bits[byteIndex] &= ~(ONE >> bitIndex);
    			}
    		}
    
    		#region Interfaces implementation
    		#region IEnumerable
    		public IEnumerator GetEnumerator()
    		{
    			//for (int i = 0; i < _length; i++) yield return this[i];
    			return this.ToArray().GetEnumerator();
    		}
    		#endregion
    		#region ICollection
    		public void CopyTo(Array array, int index)
    		{
    			if (array == null) throw new ArgumentNullException("array");
    			if (index < 0) throw new ArgumentOutOfRangeException("index");
    			if (array.Rank != 1) throw new ArgumentException("Multidimensional array not supported");
    			if (array is UInt32[]) Array.Copy(this.bits, 0, array, index, (this.Count + sizeof(UInt32) - 1) / sizeof(UInt32));
    			else if (array is bool[]) Array.Copy(this.ToArray(), 0, array, index, this.Count);
    			else throw new ArgumentException("Array type not supported (UInt32[] or bool[] only)");
    
    		}
    
    		public int Count
    		{
    			get { return this._length; }
    			private set
    			{
    				if (value > this._length) Extend(value - this._length);
    				else this._length = Math.Max(0, value);
    			}
    		}
    
    		public bool IsSynchronized
    		{
    			get { return false; }
    		}
    
    		public object SyncRoot
    		{
    			get
    			{
    				if (this._syncRoot == null) Interlocked.CompareExchange<object>(ref this._syncRoot, new object(), null);
    				return _syncRoot;
    			}
    		}
    		#endregion
    		#region ICloneable
    		public object Clone()
    		{
    			return new BoolArray(this);
    		}
    		// Not part of ICloneable, but better - returns a strongly-typed result
    		public BoolArray Dup()
    		{
    			return new BoolArray(this);
    		}
    		#endregion 
    		#endregion
    
    		#region String Conversions
    
    		public override string ToString()
    		{
    			return ToBinaryString();
    			//return ToHexString(" ", " ■ ");
    		}
    
    		public static BoolArray FromHexString(string hex)
    		{
    			if (hex == null) throw new ArgumentNullException("hex");
    
    			List<bool> bits = new List<bool>();
    			for (int i = 0; i < hex.Length; i++)
    			{
    				int b = byte.Parse(hex[i].ToString(), NumberStyles.HexNumber);
    				bits.Add((b >> 3) == 1);
    				bits.Add(((b & 0x7) >> 2) == 1);
    				bits.Add(((b & 0x3) >> 1) == 1);
    				bits.Add((b & 0x1) == 1);
    			}
    			BoolArray ba = new BoolArray(bits.ToArray());
    			return ba;
    		}
    
    		public string ToHexString(string bitSep8 = null, string bitSep128 = null)
    		{
    			string s = string.Empty;
    			int b = 0;
    			bool[] bbits = this.ToArray();
    
    			for (int i = 1; i <= bbits.Length; i++)
    			{
    				b = (b << 1) | (bbits[i - 1] ? 1 : 0);
    				if (i % 4 == 0)
    				{
    					s = s + string.Format("{0:x}", b);
    					b = 0;
    				}
    
    				if (i % (8 * 16) == 0)
    				{
    					s = s + bitSep128;
    				}
    				else if (i % 8 == 0)
    				{
    					s = s + bitSep8;
    				}
    			}
    			int ebits = bbits.Length % 4;
    			if (ebits != 0)
    			{
    				b = b << (4 - ebits);
    				s = s + string.Format("{0:x}", b);
    			}
    			return s;
    		}
    
    		public static BoolArray FromBinaryString(string bin, char[] trueChars = null)
    		{
    			if (trueChars == null) trueChars = new char[] { '1', 'Y', 'y', 'T', 't' };
    			if (bin == null) throw new ArgumentNullException("bin");
    			BoolArray ba = new BoolArray(bin.Length);
    			for (int i = 0; i < bin.Length; i++) ba[i] = bin[i].In(trueChars);
    			return ba;
    		}
    
    		public string ToBinaryString(char setChar = '1', char unsetChar = '0')
    		{
    			return new string(this.ToArray().Select(v => v ? setChar : unsetChar).ToArray());
    		}
    
    		#endregion
    
    		#region Class Methods
    		public bool[] ToArray()
    		{
    			bool[] vbits = new bool[this._length];
    			for (int i = 0; i < _length; i++) vbits[i] = this[i];
    			return vbits;
    		}
    
    		public BoolArray Append(ICollection<bool> addBits)
    		{
    			int startPos = this._length;
    			Extend(addBits.Count);
    			bool[] bitArray = addBits.ToArray();
    			for (int i = 0; i < bitArray.Length; i++) this[i + startPos] = bitArray[i];
    			return this;
    		}
    
    		public BoolArray Append(BoolArray addBits)
    		{
    			return this.Append(addBits.ToArray());
    		}
    
    		public static BoolArray Concatenate(params BoolArray[] bArrays)
    		{
    			return new BoolArray(bArrays.SelectMany(ba => ba.ToArray()).ToArray());
    		}
    
    		private void Extend(int numBits)
    		{
    			numBits += this._length;
    			int reqBytes = RequiredSize(numBits);
    			if (reqBytes > this.bits.Length)
    			{
    				UInt32[] newBits = new UInt32[reqBytes];
    				this.bits.CopyTo(newBits, 0);
    				this.bits = newBits;
    			}
    			this._length = numBits;
    		}
    
    		public bool Get(int index)
    		{
    			return this[index];
    		}
    
    		public BoolArray GetBits(int startBit = 0, int numBits = -1)
    		{
    			if (numBits == -1) numBits = bits.Length;
    			return new BoolArray(this.ToArray().Skip(startBit).Take(numBits).ToArray());
    		}
    
    		public BoolArray Repeat(int numReps)
    		{
    			bool[] oBits = this.ToArray();
    			List<bool> nBits = new List<bool>();
    			for(int i=0; i<numReps; i++) nBits.AddRange(oBits);
    			this.InitializeFrom(nBits);
    			return this;
    		}
    
    		public BoolArray Reverse()
    		{
    			int n = this.Count;
    			for(int i=0; i<n/2; i++) 
    			{
    				bool b1 = this[i];
    				this[i] = this[n - i - 1];
    				this[n - i - 1] = b1;
    			}
    			return this;
    		}
    
    		public BoolArray Set(int index, bool v)
    		{
    			this[index] = v;
    			return this;
    		}
    
    		public BoolArray SetAll(bool v)
    		{
    			for (int i = 0; i < this.Count; i++) this[i] = v;
    			return this;
    		}
    
    		public BoolArray SetBits(ICollection<bool> setBits, int destStartBit = 0, int srcStartBit = 0, int numBits = -1, bool allowExtend = false)
    		{
    			if (setBits == null) throw new ArgumentNullException("setBits");
    			if ((destStartBit < 0) || (destStartBit >= this.Count)) throw new ArgumentOutOfRangeException("destStartBit");
    			if ((srcStartBit < 0) || (srcStartBit >= setBits.Count)) throw new ArgumentOutOfRangeException("srcStartBit");
    
    			bool[] sBits;
    			if (setBits is bool[]) sBits = (bool[])setBits;
    			else sBits = setBits.ToArray();
    
    			if (numBits == -1) numBits = setBits.Count;
    			if (numBits > (setBits.Count - srcStartBit)) numBits = setBits.Count - srcStartBit;
    
    			int diffSize = numBits - (this.Count - destStartBit);
    			if (diffSize > 0)
    			{
    				if (allowExtend) Extend(diffSize);
    				else numBits = this.Count - destStartBit;
    			}
    			for (int i = 0; i < numBits; i++) this[destStartBit + i] = sBits[srcStartBit + i];
    			return this;
    		}
    
    		public List<BoolArray> SplitEvery(int numBits)
    		{
    			int i = 0;
    			List<BoolArray> bitSplits = new List<BoolArray>();
    			while (i < this.Count)
    			{
    				bitSplits.Add(this.GetBits(i, numBits));
    				i += numBits;
    			}
    			return bitSplits;
    		}
    
    		public byte[] ToBytes(int startBit = 0, int numBits = -1)
    		{
    			if (numBits == -1) numBits = this._length - startBit;
    			BoolArray ba = GetBits(startBit, numBits);
    			int nb = (numBits + 7) / 8;
    			byte[] bb = new byte[nb];
    			for (int i = 0; i < ba.Count; i++)
    			{
    				if (!ba[i]) continue;
    				int bp = 7 - (i % 8);
    				bb[i / 8] = (byte)((int)bb[i / 8] | (1 << bp));
    			}
    			return bb;
    		}
    
    
    		#endregion
    
    		#region Logical Bitwise Operations
    		public BoolArray BinaryBitwiseOp(Func<bool, bool, bool> op, BoolArray ba, int start = 0)
    		{
    			for (int i = 0; i < ba.Count; i++)
    			{
    				if (start + i >= this.Count) break;
    				this[start + i] = op(this[start + i], ba[i]);
    			}
    			return this;
    		}
    
    		public BoolArray Xor(BoolArray xor, int start = 0)
    		{
    			return BinaryBitwiseOp((a, b) => (a ^ b), xor, start);
    		}
    
    		public BoolArray And(BoolArray and, int start = 0)
    		{
    			return BinaryBitwiseOp((a, b) => (a & b), and, start);
    		}
    
    		public BoolArray Or(BoolArray or, int start = 0)
    		{
    			return BinaryBitwiseOp((a, b) => (a | b), or, start);
    		}
    
    		public BoolArray Not(int start = 0, int len = -1)
    		{
    			for (int i = start; i < this.Count; i++)
    			{
    				if (--len == -1) break;
    				this[i] = !this[i];
    			}
    			return this;
    		} 
    		#endregion
    
    		#region Class Operators
    	
    		public static BoolArray operator +(BoolArray a, BoolArray b)
    		{
    			return a.Dup().Append(b);
    		}
    
    		public static BoolArray operator |(BoolArray a, BoolArray b)
    		{
    			return a.Dup().Or(b);
    		}
    
    		public static BoolArray operator &(BoolArray a, BoolArray b)
    		{
    			return a.Dup().And(b);
    		}
    
    		public static BoolArray operator ^(BoolArray a, BoolArray b)
    		{
    			return a.Dup().Xor(b);
    		}
    
    		public static BoolArray operator ~(BoolArray a)
    		{
    			return a.Dup().Not();
    		}
    
    		public static BoolArray operator <<(BoolArray a, int shift)
    		{
    			return a.Dup().Append(new bool[shift]);
    		}
    
    		public static BoolArray operator >>(BoolArray a, int shift)
    		{
    			return new BoolArray(a.ToArray().Take(Math.Max(0, a.Count - shift)).ToArray());
    		}
    
    		public static bool operator ==(BoolArray a, BoolArray b)
    		{
    			if (a.Count != b.Count) return false;
    			for (int i = 0; i < a.Count; i++) if (a[i] != b[i]) return false;
    			return true;
    		}
    		public override bool Equals(object obj)
    		{
    			if (!(obj is BoolArray)) return false;
    			return (this == (BoolArray)obj);
    		}
    		public override int GetHashCode()
    		{
    			return this.ToHexString().GetHashCode();
    		}
    
    		public static bool operator !=(BoolArray a, BoolArray b)
    		{
    			return !(a == b);
    		}
    
    		#endregion
    	}
    }
