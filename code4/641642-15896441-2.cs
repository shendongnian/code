    public class MyClient
        {
            private const string URL = "apdu://selfdiscover/MyService.uri";
    
            public static void Main()
            {
                // create and register communication channel
                APDUClientChannel channel = new APDUClientChannel();
                ChannelServices.RegisterChannel(channel);
    
                // get the referenc to remote object
                MyService service = (MyService)Activator.GetObject(typeof(MyService), URL);
                Console.WriteLine(service.MySampleMethod());
    
                MyService.Person person = service.getPerson();
                Console.WriteLine(person.getName());
                Console.WriteLine(person.getId());
    
                Console.ReadLine();
    
                // unregister the communication channel
                ChannelServices.UnregisterChannel(channel);
            }
        }
