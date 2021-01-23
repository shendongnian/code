    public struct PreIndexStruct {
        public string Key;
        public long Offset;
        public int Count;
    }
    
    while (...) {
        ...
        PreIndexStruct pis = new PreIndexStruct();
        pis.Key = Encoding.Default.GetString(reader.ReadBytes(96));
        pis.Offset = reader.ReadInt64();
        pis.Count = reader.ReadInt32();
        structures.Add(pis);
    }
