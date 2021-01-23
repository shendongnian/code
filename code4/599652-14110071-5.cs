    using System;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    static bool ArraysCompareN<T>(T[] input, T[] output)
        where T : IEquatable<T>
    {
        if (output.Length < input.Length) return false;
        for (int x = 0; x < input.Length; x++)
            if(!output[x].Equals(input[x])) return false;
        return true;
    }
    static bool RadixEncodingTest(RadixEncoding encoding, byte[] bytes)
    {
        string encoded = encoding.Encode(bytes);
        byte[] decoded = encoding.Decode(encoded);
        return ArraysCompareN(bytes, decoded);
    }
    [TestMethod]
    public void TestRadixEncoding()
    {
        const string k_base36_digits = "0123456789abcdefghijklmnopqrstuvwxyz";
        var base36 = new RadixEncoding(k_base36_digits, EndianFormat.Little, true);
        var base36_no_zeros = new RadixEncoding(k_base36_digits, EndianFormat.Little, true);
        byte[] ends_with_zero_neg = { 0xFF, 0xFF, 0x00, 0x00 };
        byte[] ends_with_zero_pos = { 0xFF, 0x7F, 0x00, 0x00 };
        byte[] text = System.Text.Encoding.ASCII.GetBytes("A test 1234");
        Assert.IsTrue(RadixEncodingTest(base36, ends_with_zero_neg));
        Assert.IsTrue(RadixEncodingTest(base36, ends_with_zero_pos));
        Assert.IsTrue(RadixEncodingTest(base36_no_zeros, text));
    }
