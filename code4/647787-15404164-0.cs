    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            var mainvm = new MainWindowViewModel();
            var window = new MainWindow
            {
                DataContext = mainvm
            };
            window.Show();
            mainvm.Messages.Add(new OutgoingMessage{ MessageContent = "Help me please!"});
            mainvm.Messages.Add(new IncomingMessage { MessageContent = "What do you want" });
            mainvm.Messages.Add(new OutgoingMessage { MessageContent = "I want a ListBox" });
            mainvm.Messages.Add(new IncomingMessage { MessageContent = "Then?" });
            mainvm.Messages.Add(new OutgoingMessage { MessageContent = "But the Grid won't fill" });
        }
    }
