    public class GroupsViewModel : ViewModelBase // This implementation uses Mvvm Light's ViewModelBase, feel free to use any
    {
        public ObservableCollection<Group<Item>> AllGroups { get; set; }
        
        public GroupsViewModel()
        {
            AllGroups = new ObservableCollection<Group<Item>>();
            
            Group<Item> group1 = new Group<Item>();
            group1.Title = "Group 1 Title";
            group1.Add(new Item(){ Value = "The first value." });
            AllGroups.Add(group1);
            
            Group<Item> group2 = new Group<Item>();
            group2.Title = "Group 2 Title";
            group2.Add(new Item(){ Value = "The second value." });
        }
    }
