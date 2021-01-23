    public class PriorityCheckboxes {
        private static CheckBox _CBItems = null;
        private static PriorityCheckboxes _instance - null;
        public CheckBox CheckBoxes { 
            get() { return _CBItems; } 
        }
        private PriorytyCheckboxes() {
            this.LoadCBItems();
            _instance = new PriorityCheckboxes();
        }
        public static PriorityCheckboxes GetInstance() { 
            if(_instance == null ) _instance = new PriorityCheckboxes();
            return _instance;
        }
        private void LoadCBItems() { }
    }
