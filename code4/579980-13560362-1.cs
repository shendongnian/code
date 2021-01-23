        private static void Main(string[] args) {
            var messenger = new MessageDispatcher();
            messenger.Register<Message>(m => Console.WriteLine(m.Text));
            messenger.Send(new Message() { Text = "Good morning, sir."});
            messenger.Register<Message>(m => Console.WriteLine(m.Text + " It's nice weather today."));
            messenger.Register<Notification>(n => Console.WriteLine(n.Text));
            messenger.Send(new Message() { Text = "How do you feel? "});
            messenger.Send(new Notification() { Text = "Cup of tea, sir?" });
            messenger.Deregister<Message>();
            messenger.Send(new Message() { Text = "Good bye" });
            Console.ReadLine();
        }
        public class Message {
            public string Text { get; set; }
        }
        public class Notification {
            public string Text { get; set; }
        }
