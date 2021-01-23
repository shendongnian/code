    public class DataTemplateItemsControlViewModel
    {
        public DataTemplateItemsControlViewModel()
        {
            Items =
                new Collection<MyClass>
                    {
                        new MyClass
                            {
                                Text = "ACTION1", 
                                BackColor = new SolidColorBrush(Colors.Red)
                            },
                        new MyClass
                            {
                                Text = "ACTION2", 
                                BackColor = new SolidColorBrush(Colors.Blue)
                            },
                        new MyClass
                            {
                                Text = "ACTION3", 
                                BackColor = new SolidColorBrush(Colors.Green)
                            },
                        new MyClass
                            {
                                Text = "ACTION4", 
                                BackColor = new SolidColorBrush(Colors.Yellow)
                            },
                    };
        }
        public IList<MyClass> Items { get; private set; }
    }
