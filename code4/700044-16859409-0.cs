    foreach (Microsoft.Phone.Net.NetworkInformation.NetworkInterfaceInfo specificInterface in InterfacesList)
        {
            if (specificInterface.InterfaceType == Microsoft.Phone.Net.NetworkInformation.NetworkInterfaceType.Wireless80211)
            {
               Console.WriteLine("This interface is a Wifi Interface :");
            }
            Console.WriteLine("Bandwidth :" + specificInterface.Bandwidth);
            Console.WriteLine("Characteristics :" + specificInterface.Characteristics);
            Console.WriteLine("Description :" + specificInterface.Description);
            Console.WriteLine("InterfaceName :" + specificInterface.InterfaceName);
            Console.WriteLine("InterfaceType :" + specificInterface.InterfaceType);
        }
