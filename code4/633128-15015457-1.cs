    private static void Move()
            {
                try
                {
                    File.Move(@"Debug\Settings.zip", System.Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments));
                }
                catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
