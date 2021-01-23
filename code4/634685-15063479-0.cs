        public IList<MyComboboxItem> Actions
        {
            get
            {
                var list = new List<MyComboboxItem> { new MyComboboxItem(AddFunction), new MyComboboxItem(SubtractFunction) };
                return list;
            }
        }
        public int numberA { get;  set; }
        public int numberB { get; set; }
        public int Result { get; private set; }
        public void AddFunction()
        {
            Result = numberA + numberB;
        }
        public void SubtractFunction()
        {
            Result = numberA - numberB;
        }
        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var comboboxItem = e.AddedItems[0] as MyComboboxItem;
            if (comboboxItem != null)
                comboboxItem.Action.Invoke();
        }
        public event PropertyChangedEventHandler PropertyChanged;
      public class MyComboboxItem 
      {
        public Action Action { get; private set; } 
        
        public MyComboboxItem(Action action)
        {
            this.Action = action;
        }
        public override string ToString()
        {
            return Action.Method.Name;
        }
    }
