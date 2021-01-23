     public enum EditingType
        {
            Display,
            Editing
        }
         
        public class Form2
         {
            private EditingType _editingType;
    
            public Form2(EditingType editingType)
            {
                _editingType = editingType;
            }
    
            public void DoSomething()
            {
                if (_editingType == EditingType.Display)
                {
                    // display mode
                }
    
                if (_editingType == EditingType.Editing)
                {
                    // editing mode
                }
            }
         }
