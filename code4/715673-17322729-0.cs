    using System;
    using System.Net;
    using System.Threading;
    using Microsoft.WindowsAzure;
    using Microsoft.WindowsAzure.ServiceRuntime;
    using Microsoft.WindowsAzure.StorageClient;
    using System.Threading.Tasks;
    namespace ThreadedWriterTest
    {
        public class WorkerRole : RoleEntryPoint
        {
            private static CloudStorageAccount storageAccount;
            private static Semaphore semaphore = new Semaphore(3, 3);
            public override void Run()
            {
                while (true)
                {
                    semaphore.WaitOne();
                    Task.Factory.StartNew(()=> writeStuff());
                }
            }
            private void writeStuff()
            {
                CloudBlobClient threadClient = storageAccount.CreateCloudBlobClient();
                threadClient.GetBlobReference("threadtest/" + Guid.NewGuid().ToString()).UploadText("Hello " + Guid.NewGuid().ToString());
                semaphore.Release();
            }
            public override bool OnStart()
            {
                ServicePointManager.DefaultConnectionLimit = 12;
                storageAccount = CloudStorageAccount.Parse(CloudConfigurationManager.GetSetting("XXX"));
                return base.OnStart();
            }
        }
    }
