    public class Class : Control, INotifyPropertyChanged
    {
        // Property that's raised to let other clases know when a property has changed.
        public event PropertyChangedEventHandler PropertyChanged;
    
        // Flags to show what's going on with this class.
        bool isClassComplete;
        bool isPreComplete;
    
        // Some other info about the class.
        public string ClassName { get; set; }
        public string Description { get; set; }
    
        // A list of prerequisite classes to this one.
        List<Class> prerequisites;
    
        // public property access to the complete class, you can only set it to true
        // if the prerequisite classes are all complete.
        public bool IsClassComplete
        {
            get { return isClassComplete; }
            set
            {
                if (isPreComplete)
                    isClassComplete = value;
                else
                    if (value)
                        throw new Exception("Class can't be complete, pre isn't complete");
                    else
                        isClassComplete = value;
    
                PropertyChangedEventHandler temp = PropertyChanged;
                if (temp != null)
                    temp(this, new PropertyChangedEventArgs("IsClassComplete"));
            }
        }
    
        // public readonly property access to the complete flag.
        public bool IsPreComplete { get { return isPreComplete; } }
    
        public Class()
        {
            prerequisites = new List<Class>();
            isPreComplete = true;
        }
    
        // adds a class to the prerequisites list.
        public void AddPre(Class preClass)
        {
            prerequisites.Add(preClass);
            preClass.PropertyChanged += new PropertyChangedEventHandler(preClass_PropertyChanged);
            ValidatePre();
        }
    
        // removes a class from the prerequisites lists.
        public void RemovePre(Class preClass)
        {
            prerequisites.Remove(preClass);
            preClass.PropertyChanged -= new PropertyChangedEventHandler(preClass_PropertyChanged);
            ValidatePre();
        }
    
        // each time a property changes on one of the prerequisite classes this is run.
        void preClass_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "IsClassComplete":
    
                    // check to see if all prerequisite classes are complete/
                    ValidatePre();
                    break;
            }
        }
    
        void ValidatePre()
        {
            if (prerequisites.Count > 0)
            {
                bool prerequisitesComplete = true;
                for (int i = 0; i < prerequisites.Count; i++)
                    prerequisitesComplete &= prerequisites[i].isClassComplete;
                isPreComplete = prerequisitesComplete;
                if (!isPreComplete)
                    IsClassComplete = false;
            }
            else
                isPreComplete = true;
    
            PropertyChangedEventHandler temp = PropertyChanged;
            if (temp != null)
                temp(this, new PropertyChangedEventArgs("IsPreComplete"));
        }
    }
