    class Program
        {
            static int Main(string[] args)
            {
                //make sure the correct number of arguments are being passed.
                if (args.Length !=5)
                {
                    Console.WriteLine("not thr right number of args. \nUsage SFTPUploadFile <host> <port> <username> <password> <localFilePath>");
                    return 1;
                }
               
                Console.WriteLine("You had the right number of args.");
                return 0;        
            }
    
        }
