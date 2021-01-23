    namespace SilverlightApplication2
    {
        public partial class MainPage : UserControl 
        {
            public ObservableCollection<Parent> ParentList { get; set; }
    
            public MainPage()
            {
                Populate();
                InitializeComponent();
            }
            private void Save_Click(object sender, RoutedEventArgs e)
            {
              foreach (var child in ParentList
                .SelectMany(p => p.Children)
                .Where(c => c.IsSelected))
              {
                //Save the child
                Debug.WriteLine(string.Format("Child {0} saved", child.Name));
              }
            }
    
            private void Populate()
            {
                ParentList = new ObservableCollection<Parent>();
                ParentList.Add(new Parent
                {
                    Name = "John",
                    Children = new List<Child> { new Child { Name = "Paul" }, new Child { Name = "Pat" } }
                });
    
                ParentList.Add(new Parent
                {
                    Name = "Mike",
                    Children = new List<Child> { new Child { Name = "Bob" }, new Child { Name = "Alice" } }
                });
    
                ParentList.Add(new Parent
                {
                    Name = "Smith",
                    Children = new List<Child> { new Child { Name = "Ryan" }, new Child { Name = "Sue" }, new Child { Name = "Liz" } }
                });
            }
        }
    
        public class Parent
        {
            public string Name { get; set; }
            public List<Child> Children { get; set; }
        }
    
        public class Child
        {
            public string Name { get; set; }
            public bool IsSelected { get; set; }
        }
    }
