    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Microsoft.WindowsAzure;
    using Microsoft.WindowsAzure.Diagnostics;
    using Microsoft.WindowsAzure.ServiceRuntime;
    using Microsoft.WindowsAzure.StorageClient;
    using System.Threading.Tasks;
    namespace MvcWebRole1
    {
        public class WebRole : RoleEntryPoint
        {
            public override bool OnStart()
            {
                Task.Factory.StartNew(InitializeQueueListener);
                return base.OnStart();
            }
            private void InitializeQueueListener()
            {
                Microsoft.WindowsAzure.CloudStorageAccount.SetConfigurationSettingPublisher((configName, configSetter) =>
                {
                    configSetter(Microsoft.WindowsAzure.ServiceRuntime.RoleEnvironment.GetConfigurationSettingValue(configName));
                });
                var storageAccount = CloudStorageAccount.FromConfigurationSetting("DataConnectionString");
                var queueStorage = storageAccount.CreateCloudQueueClient();
                var queue = queueStorage.GetQueueReference("myqueue");
                queue.CreateIfNotExist();
                while (true)
                {
                    CloudQueueMessage msg = queue.GetMessage();
                    if (msg != null)
                    {
                        // DO SOMETHING HERE
                        queue.DeleteMessage(msg);
                    }
                    else
                    {
                        System.Threading.Thread.Sleep(1000);
                    }
                }
            }
        }
    }
