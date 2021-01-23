            //Saving the DataTable
            workspace.TableName = "SomeName"; //A name is required in order to save the datable
            var dtSerializer = new XmlSerializer(typeof(DataTable));
            dtSerializer.Serialize(File.Create("out.xml"), workspace);
            //Reading saved data
            var dtDeserializer = new XmlSerializer(typeof(DataTable));
            var data = (DataTable)dtDeserializer.Deserialize(File.Open("out.xml", FileMode.Open));
