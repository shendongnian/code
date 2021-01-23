            foreach (var item in System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces())
            {
                Console.Write(item.Name + " - " + item.OperationalStatus.HasFlag(System.Net.NetworkInformation.OperationalStatus.Up) + " : ");
                foreach (var item2 in item.GetIPProperties().UnicastAddresses)
                {
                    if (!item2.Address.IsIPv6LinkLocal)
                        Console.Write(item2.Address.ToString());
                }
                Console.WriteLine();
            }
