    public static class int32crypto
    {
        // C# follows ECMA 334v4, so Integer Literals have only two possible forms -
        // decimal and hexadecimal.
        // Original key:               0b11010101111000100101101100111101
        public static long baseKey = 0xD5E25B3D;
        public static long encrypt(long value)
        {
            // First we will extract from our baseKey the bits we'll actually use.
            // We do this with an AND mask, indicating the bits to extract.
            // Remember, we'll ignore the first 8. So the mask must look like this:
            // Significance mask:      0b00000000111111111111111111111111
            long _sigMask = 0x00FFFFFF;
            // sigKey is our baseKey with only the indicated bits still true.
            long _sigKey = _sigMask & baseKey;
            // nonce generation. First security issue, since Random()
            // is time-based on its first iteration. But that's OK for the sake
            // of explanation, and safe for most circunstances.
            // The bits it will occupy are the first eight, like this:
            // OriginalNonce:          0b000000000000000000000000NNNNNNNN
            long _tempNonce = new Random().Next(255);
            // We now shift them to the last byte, like this:
            // finalNonce:             0bNNNNNNNN000000000000000000000000
            _tempNonce = _tempNonce << 0x18;
            // And now we mix both Nonce and sigKey, 'poisoning' the original
            // key, like this:
            long _finalKey = _tempNonce | _sigKey;
            // Phew! Now we apply the final key to the value, and return
            // the encrypted value.
            return _finalKey ^ value;
        }
        public static long decrypt(long value)
        {
            // This is easier than encrypting. We will just ignore the bits
            // we know are used by our nonce.
            long _sigMask = 0x00FFFFFF;
            long _sigKey = _sigMask & baseKey;
            // We will do the same to the informed value:
            long _trueValue = _sigMask & value;
            // Now we decode and return the value:
            return _sigKey ^ _trueValue;
        }
    }
