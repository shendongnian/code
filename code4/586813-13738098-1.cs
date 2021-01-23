            public static void Log(String logMessage, TextWriter writer)
            {
                writer.Write("\r\nLog Entry : ");
                writer.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                writer.WriteLine("  :");
                writer.WriteLine("  :{0}", logMessage);
                writer.WriteLine("-------------------------------");
                // Update the underlying file.
                writer.Flush();
            }
