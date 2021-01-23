    namespace LongListSelectorDemo.Model
    {
        public class FoodItem
        {
            public FoodItem(string name, string groupName)
            {
                Name = name;
                GroupName = groupName;
            }
            public string Name { get; private set; }
            public string GroupName { get; private set; }
        }
    }
