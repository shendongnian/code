public object BytesToObject(byte[] bytes)
{
        MemoryStream ms = new MemoryStream(bytes);
        BinaryFormatter bf= new BinaryFormatter();
        ms.Position = 0;
        return bf.Deserialize(ms);
}
</pre>
