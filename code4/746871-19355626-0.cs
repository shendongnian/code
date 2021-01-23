    using PCSC;
    
    namespace SmartcardCheck
    {
        class Program
        {
            static void Main(string[] args)
            {
                using (var context = new SCardContext())
                {
                    context.Establish(SCardScope.System);
    
                    string[] readerNames = null;
                    try
                    {
                        // retrieve all reader names
                        readerNames = context.GetReaders();
    
                        // get the card status of each reader that is currently connected
                        foreach (var readerName in readerNames)
                        {
                            using (var reader = new SCardReader(context))
                            {
                                Console.WriteLine("Trying to connect to reader {0}.", readerName);
                                
                                var sc = reader.Connect(readerName, SCardShareMode.Shared, SCardProtocol.Any);
                                if (sc == SCardError.Success)
                                {
                                    DisplayReaderStatus(reader);
                                }
                                else
                                {
                                    Console.WriteLine("No card inserted or reader is reserved exclusively by another application.");
                                    Console.WriteLine("Error message: {0}\n", SCardHelper.StringifyError(sc));
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        if (readerNames == null)
                        {
                            Console.WriteLine("No readers found.");
                            return;
                        }
                    }
                    
                    Console.ReadKey();
                }
            }
        }
    }
