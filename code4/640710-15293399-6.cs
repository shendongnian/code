	public void CryptoBuffer(byte[] buffer, ushort magicShort) {
		var magicBytes=BitConverter.GetBytes(magicShort);
		var count=buffer.Length;
		for(var i=0; i<count; i++) {
			buffer[i]^=magicBytes[1];
			buffer[i]+=magicBytes[0];
		}
	}
	int Analyze(
		Action<byte[], ushort> subject,
		byte[] expected, byte[] original,
		ushort? magicShort=default(ushort?)
		) {
		Func<byte[], String> LaHeX= // narrowing bytes to hex statement
			arg => arg.Select(x => String.Format("{0:x2}\x20", x)).Aggregate(String.Concat);
		var temporal=(byte[])original.Clone();
		var found=0;
		for(var i=ushort.MaxValue; i>=0; --i) {
			if(found>255) {
				Console.WriteLine(": might found more than the number of square root; ");
				Console.WriteLine(": analyze stopped ");
				Console.WriteLine();
				break;
			}
			subject(temporal, magicShort??i);
			if(expected.SequenceEqual(temporal)) {
				++found;
				Console.WriteLine("i={0:x2}; temporal={1}", i, LaHeX(temporal));
			}
			if(expected!=original)
				temporal=(byte[])original.Clone();
		}
		return found;
	}
	void PerformTest() {
		var original=new byte[] { 0xa5, 0x03, 0x18, 0x01 };
		var expected=new byte[] { 0xa5, 0x6f, 0x93, 0x8b };
		Console.WriteLine("--- reproducibility analysis --- ");
		Console.WriteLine("found: {0}", Analyze(CryptoBuffer, original, original, 0xaac9));
		Console.WriteLine();
		Console.WriteLine("--- feasibility analysis --- ");
		Console.WriteLine("found: {0}", Analyze(CryptoBuffer, expected, original));
		Console.WriteLine();
		// swap original and expected
		var temporal=original;
		original=expected;
		expected=temporal;
		Console.WriteLine("--- reproducibility analysis --- ");
		Console.WriteLine("found: {0}", Analyze(CryptoBuffer, original, original, 0xaac9));
		Console.WriteLine();
		Console.WriteLine("--- feasibility analysis --- ");
		Console.WriteLine("found: {0}", Analyze(CryptoBuffer, expected, original));
		Console.WriteLine();
	}
