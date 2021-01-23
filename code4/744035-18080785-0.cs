            TreeViewItem GreetingItem = new TreeViewItem()
            {
                Header = "Greetings",
                ContextMenu = new ContextMenu //CONTEXT MENU
                {
                    Background = Brushes.White,
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(1),
                }
            };
            MenuItem sayGoodMorningMenu = new MenuItem() { Header = "Say Good Morning" };
            sayGoodMorningMenu.Click += (o, a) =>
            {
                MessageBox.Show("Good Morning");
            };
            MenuItem sayHelloMenu = new MenuItem() { Header = "Say Hello" };
            sayHelloMenu.Click += (o, a) =>
                {
                    MessageBox.Show("Hello");
                };
            GreetingItem.ContextMenu.Items.Add(sayHelloMenu);
            GreetingItem.ContextMenu.Items.Add(sayGoodMorningMenu);
            this.treeView.Items.Add(GreetingItem);
