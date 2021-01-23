    public class yourclass
    {
        public string Key { get; set; }
        public int Value { get; set; }
    }
    
    
    ObservableCollection<yourclass> dict = new ObservableCollection<MyCustomClass>();
    dict.Add(new yourclass{Key = "yourkey", Value = whatyouwant});
    dict.Add(new yourclass{ Key = "yourkey2", Value = whatyouwant });
