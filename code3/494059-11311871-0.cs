           try
            {
                DirectoryInfo diNoServer = new DirectoryInfo(@"\\non.existant.server\share");
                diNoServer.Attributes = diNoServer.Attributes;
                if (!diNoServer.Exists)
                {
                    Console.WriteLine("The server was responsive, but the directory did not exist");
                }
                else
                {
                    Console.WriteLine("all good");
                }
            }
            catch (IOException exception)
            {
                Console.WriteLine("The server was unreachable");
            }
