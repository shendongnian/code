    public static CloudBlobContainerExtensions {
        public static CloudBlobContainer GetContainer(this EnumTypes.BlobContainerNames BlobContainerName)
        {
            return CloudStorageAccount.DevelopmentStorageAccount.CreateCloudBlobClient().GetContainerReference(Enum.GetName(typeof(EnumTypes.BlobContainerNames), BlobContainerName));
        }
    }
    //elsewhere
    var myContainer = CloudBlobContainer.GetContainer(EnumTypes.BlobContainerNames.SomeName);
