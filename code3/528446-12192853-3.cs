       public static void Save<T>(string fileName, List<T> list)
        {
            // Gain code access to the file that we are going
            // to write to
            try
            {
                // Create a FileStream that will write data to file.
                using (var stream = new FileStream(fileName, FileMode.Create, FileAccess.Write))
                {
                    var formatter = new BinaryFormatter();
                     formatter.Serialize(stream, list);
                }
            }
            catch (Exception ex)
            {
               Console.WriteLine(ex.Message);
            }
        }
