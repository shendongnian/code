    // DTO Class
    public class Instance
    {
       public string Instance_Start { get; set; }
       public string Instance_Stop { get; set; }
    }
    var instanceList = new List<Instance>;
    var file = new System.IO.StreamReader(myFile);
    while(!file.EndOfStream)
    {
        var instance = new Instance
        {
            Instance_Start = file.Readline();
            Instance_Stop = file.Readline();
        };
        instanceList.Add(instance);
        num_instance++;
    }
