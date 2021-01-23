    var bytes = Enumerable.Range(0, 256).Select(p => (byte)p).ToArray();
    var all1bytechars = new string(bytes.Select(p => (char)p).ToArray());
    var enc = Encoding.GetEncoding("ISO-8859-1");
    var bytes2 = enc.GetBytes(all1bytechars);
    var all1bytechars2 = enc.GetString(bytes);
    Debug.Assert(bytes.SequenceEqual(bytes2));
    Debug.Assert(all1bytechars.SequenceEqual(all1bytechars2));
