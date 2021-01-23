           try
            {
                if (File.Exists("C:\\Test.txt"))
                {
                    //write file
                    using (var stream = new FileStream("C:\\Test.txt", FileMode.CreateNew))
                    using (var writer = new StreamWriter(stream))
                    {
                        //The actual writing of file
                    }
                }
            }
            catch (IOException ex)
            {
                //how do I know this is because a file exists?
                Debug.Print(ex.Message);
            }
