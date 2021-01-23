    // Bytes with all the possible values 0-255
    var bytes = Enumerable.Range(0, 256).Select(p => (byte)p).ToArray();
    // String containing the values
    var all1bytechars = new string(bytes.Select(p => (char)p).ToArray());
    // Sanity check
    Debug.Assert(all1bytechars.Length == 256);
    // The encoder, you could make it static readonly
    var enc = Encoding.GetEncoding("ISO-8859-1"); // It is the codepage 28591
    // string-to-bytes
    var bytes2 = enc.GetBytes(all1bytechars);
    // bytes-to-string
    var all1bytechars2 = enc.GetString(bytes);
    // check string-to-bytes
    Debug.Assert(bytes.SequenceEqual(bytes2));
    // check bytes-to-string
    Debug.Assert(all1bytechars.SequenceEqual(all1bytechars2));
