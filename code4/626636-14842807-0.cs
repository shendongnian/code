    [Serializable]
    public class SomeClass
    {
        // Serialize the list as an array with the form:
        //  <OpenDrawerCommand>
        //      <byte>...</byte>
        //      <byte>...</byte>
        //      <byte>...</byte>
        //  </OpenDrawerCommand>
        [System.Xml.Serialization.XmlArray("OpenDrawerCommand")]
        [System.Xml.Serialization.XmlArrayItemAttribute("byte")]
        public List<byte> CommandBytes {get; set;}
    }
    void Main()
    {
        var cmd = new SomeClass() 
        { 
            CommandBytes = new List<byte> { 27, 112, 48, 55, 121 }
        };
        var originalBytes = cmd.CommandBytes;
        
        var sb = new StringBuilder();
        var ser = new System.Xml.Serialization.XmlSerializer(typeof(SomeClass));
        using(var sw = new StringWriter(sb))
        using(var xw = XmlWriter.Create(sw))
            ser.Serialize(xw, cmd);
        Console.WriteLine(sb.ToString());
        
        cmd = new SomeClass();
        Debug.Assert(cmd.CommandBytes == null);
        
        using(var sr = new StringReader(sb.ToString()))
        using(var xr = XmlReader.Create(sr))
            cmd = (SomeClass)ser.Deserialize(xr);
        Debug.Assert(cmd.CommandBytes.SequenceEqual(originalBytes));
        
        Console.WriteLine(string.Join(", ", cmd.CommandBytes));
    }
