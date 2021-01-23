    static void Main(string[] args)
    {
        var blob = CloudStorageAccount.DevelopmentStorageAccount
            .CreateCloudBlobClient().GetBlobReference(args[0]);
        // or CloudStorageAccount.Parse("<your connection string>")
    
        if (blob.Exists())
        {
            Console.WriteLine("The blob exists!");
        }
        else
        {
            Console.WriteLine("The blob doesn't exist.");
        }
    }
