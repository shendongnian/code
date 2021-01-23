    #region Save the object
    
                // Create a new XmlSerializer instance with the type of the test class
                XmlSerializer SerializerObj = new XmlSerializer(typeof(List<Item>));
    
                // Create a new file stream to write the serialized object to a file
                TextWriter WriteFileStream = new StreamWriter(@"C:\test.xml");
                SerializerObj.Serialize(WriteFileStream, lstNewItems);
    
                // Cleanup
                WriteFileStream.Close();
    
                #endregion
    
                // Load items to control
                #region Load the object
    
                // Create a new file stream for reading the XML file
                FileStream ReadFileStream = new FileStream(@"C:\test.xml", FileMode.Open, FileAccess.Read, FileShare.Read);
    
                // Load the object saved above by using the Deserialize function
                List<Item> LoadedObj = (List<Item>)SerializerObj.Deserialize(ReadFileStream);
    
                // Cleanup
                ReadFileStream.Close();
    
                #endregion
    
                // Load up all the settings
    
                for (int i = 0; i < LoadedObj.Count; i++) // Loop through List with for
                {
                    String ThisisAnItemToControl = LoadedObj[i].Paramater;
                    String ThisIsItsType = LoadedObj[i].Type;
                } 
