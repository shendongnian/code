public byte[] ObjectToByteArray(Object obj)
{
    BinaryFormatter bf = new BinaryFormatter();
    MemoryStream ms = new MemoryStream();
    bf.Serialize(ms, obj);
    return ms.ToArray();
}
</pre>
