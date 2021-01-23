     public class ModelList : List<string>
        {
            public ModelList()
            {
                Add("John");
                Add("Jack");
                Add("Sue");
            }
    
            public int CurrentIndex = 0;
            public string CurrentItem
            {
                get
                {
                    return this[CurrentIndex];
                }
            }
        }
