    List<data> _data = new List<data>();
    _data.Add(new data()
    {
        Id = 1,
        SSN = 2,
        Message = "A Message"
    });
    string json = JsonConvert.SerializeObject(_data.ToArray());
    //write string to file
    System.IO.File.WriteAllText (@"D:\path.txt", json);
