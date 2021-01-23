    var m = new System.IO.MemoryStream();
    var b = new
    System.Runtime.Serialization.Formatters.Binary.BinaryFormatter();
    b.Serialize(m, Obj);
    var size = Convert.ToDouble(m.Length);
