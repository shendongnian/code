    using System;
    using System.Collections.ObjectModel;
    using System.Threading;
    
    namespace WpfApplication
    {
        class ViewModel
        {
            public ObservableCollection<Item> Items { get; private set; }
            public ObservableCollection<ItemProperty> ItemProperties { get; private set; }
    
            public ViewModel()
            {
                this.Items = new ObservableCollection<Item>();
                this.ItemProperties = new ObservableCollection<ItemProperty>();
    
                for (int i = 0; i < 1000; ++i)
                    this.Items.Add(new Item("Name " + i) { Kind = (ItemKind)(i % 3), IsChecked = (i % 2) == 1, Link = new Uri("http://www.link" + i + ".com") });
            }
    
            private bool testStarted;
    
            // Test method operates on another thread and it will first add all columns one by one in interval of 1 second, and then remove all columns one by one in interval of 1 second. 
            // Adding and removing will be repeated indefinitely.
            public void Test()
            {
                if (this.testStarted)
                    return;
    
                this.testStarted = true;
    
                ThreadPool.QueueUserWorkItem(state =>
                {
                    var itemProperties = new ItemProperty[]
                    {
                        new ItemProperty(typeof(string), "Name", true),
                        new ItemProperty(typeof(ItemKind), "Kind", false),
                        new ItemProperty(typeof(bool), "IsChecked", false),
                        new ItemProperty(typeof(Uri), "Link", false)
                    };
    
                    bool removing = false;
    
                    while (true)
                    {
                        Thread.Sleep(1000);
    
                        if (removing)
                        {
                            if (this.ItemProperties.Count > 0)
                                this.ItemProperties.RemoveAt(this.ItemProperties.Count - 1);
                            else
                                removing = false;
                        }
                        else
                        {
                            if (this.ItemProperties.Count < itemProperties.Length)
                                this.ItemProperties.Add(itemProperties[this.ItemProperties.Count]);
                            else
                                removing = true;
                        }
                    }
                });
            }
        }
    }
