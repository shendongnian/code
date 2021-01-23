    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new[] 
            {
                new MailFolder
                {
                    Name = "Prejeto",
                    SubFolders = 
                    {
                        new MailFolder
                        {
                            Name = "Prebrano",
                            Items = 
                            {
                                new MailItem { Subject = "A" },
                                new MailItem { Subject = "B" },
                                new MailItem { Subject = "C" },
                            }
                        },
                        new MailFolder
                        {
                            Name = "Neprebrano",
                            Items = 
                            {
                                new MailItem { Subject = "D" },
                                new MailItem { Subject = "E" },
                            }
                        },
                    },
                    Items = 
                    {
                        new MailItem { Subject = "M" },
                        new MailItem { Subject = "N" },
                    }
                },
                new MailFolder
                {
                    Name = "Poslano",
                    Items = 
                    {
                        new MailItem { Subject = "F" },
                        new MailItem { Subject = "G" },
                    }
                },
                new MailFolder
                {
                    Name = "Osnutki",
                    Items = 
                    {
                        new MailItem { Subject = "H" },
                    }
                },
                new MailFolder
                {
                    Name = "Izbrisano",
                    Items = 
                    {
                        new MailItem { Subject = "I" },
                        new MailItem { Subject = "J" },
                        new MailItem { Subject = "K" },
                    }
                },
                new MailFolder
                {
                    Name = "Nezaželeno",
                    Items = 
                    {
                        new MailItem { Subject = "L" },
                    }
                }
            };
        }
    }
