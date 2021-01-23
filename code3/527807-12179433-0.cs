     public class Notifier
        {
            public static void Say(string message)
            {
                var context = GlobalHost.ConnectionManager.GetHubContext<MyHub>();
                context.Clients.say(message);
            }
        }
    }
