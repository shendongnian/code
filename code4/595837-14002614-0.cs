    var jsonSerializer = new JsonSerializer();
                    dynamic stuff = jsonSerializer.Deserialize(new JsonTextReader(new StringReader(json)));
                    var ffff = stuff.response.message;
    
                    var jss = new JsonSerializer();
                    dynamic st = jsonSerializer.Deserialize(new JsonTextReader(new StringReader((string)ffff)));
    
                    var bv = 0;
                    foreach (var msg in st)
                    {
                        bv++;
                    }
