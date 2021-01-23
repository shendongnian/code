     public class Filters
    {
        private int oem;
        private int item;
        private int group;
        private bool active;
        private bool ninventoried;
        private bool stocked;
        public int OEM
        {
            set { oem = value; }
            get { return oem; }
        }
        public int Item
        {
            set { item = value; }
            get { return item; }
        }
        public int Group
        {
            set { group = value; }
            get { return group; }
        }
        public bool Active
        {
            set { active = value; }
            get { return active; }
        }
        public bool Ninventoried
        {
            set { ninventoried = value; }
            get { return ninventoried; }
        }
        public bool Stocked
        {
            set { stocked = value; }
            get { return stocked; }
        }
    }
