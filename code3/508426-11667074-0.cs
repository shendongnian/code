    System.Runtime
          .Serialization
          .Formatters
          .Binary
          .BinaryFormatter binary = new System.Runtime
                                         .Serialization
                                         .Formatters
                                         .Binary.BinaryFormatter();
            using (FileStream fs = File.Create(file))
            {
                bs.Serialize(fs, objectArray);
            }
