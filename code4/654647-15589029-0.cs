    using System.Runtime.Serialization.Formatters.Binary;
    
    // Server side
    Stream stream = new NetworkStream(socket);
    var bin = new BinaryFormatter();
    bin.Serialize(stream, TaskManager());
    
    // Client side
    Stream stream = new NetworkStream(socket);
    var bin = new BinaryFormatter();
    var list = (List<string>)bin.Deserialize(stream);
