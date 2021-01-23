     [Serializable]
            class numOne
            {
                public string name;
                public int age;
            }
            [Serializable]
            class numTwo
            {
                public string rg;
            }
            private void Button_Click_1(object sender, RoutedEventArgs e)
            {
    //Serialization
                using (var fs = new FileStream("DataFile.dat", FileMode.Create))
                {
                    var listToBeSerialized = new ArrayList(){                
                    new numOne() { name = "sth", age = 18 },
                    new numTwo() { rg = "FileAddress" }
                };
                    new BinaryFormatter().Serialize(fs, listToBeSerialized);
                }
    
    //Deserialization
                using (var fs = new FileStream("DataFile.dat", FileMode.Open))
                {
                    var deserializedList = (ArrayList)new BinaryFormatter().Deserialize(fs);
                }
            }
