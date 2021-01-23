                VMState vmState = VMState.Undefined;
                var connectionOptions = new ConnectionOptions();
                connectionOptions.Username = userName;
                connectionOptions.Password = password;
                var managementScope= new ManagementScope(string.Format(@"\\{0}\root\virtualization", hostServer), connectionOptions );
                manScope.Connect();  
                var objectQuery= new ObjectQuery("SELECT * FROM Msvm_ComputerSystem");
                var managementObjectSearcher  = new ManagementObjectSearcher(managementScope, objectQuery);
                var collection = managementObjectSearcher.Get();
    
                foreach (var managementObject  in collection )
                {
                   Console.WriteLine(managementObject["Yourkey"].ToString());
                }
