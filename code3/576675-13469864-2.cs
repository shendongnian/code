    string[,] famousCouples = new string[,]
      {
        { "Adam", "Eve" },
        { "Bonnie", "Clyde" },
        { "Donald", "Daisy" },
        { "Han", "Leia" }
      };
     
    string json = JsonConvert.SerializeObject(famousCouples, Formatting.Indented);
    // [
    //   ["Adam", "Eve"],
    //   ["Bonnie", "Clyde"],
    //   ["Donald", "Daisy"],
    //   ["Han", "Leia"]
    // ]
     
    string[,] deserialized = JsonConvert.DeserializeObject<string[,]>(json);
     
    Console.WriteLine(deserialized[3, 0] + ", " + deserialized[3, 1]);
    // Han, Leia
