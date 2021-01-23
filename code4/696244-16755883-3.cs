    ripped from http://www.andrewdenhertog.com/c/create-dependencyproperty-dependencyobject-5-minutes/
    public int Age
        {
            get { return (int)GetValue(AgeProperty); } //do NOT modify anything in here
            set { SetValue(AgeProperty, value); } //...or here
        }
        // Using a DependencyProperty as the backing store for Age.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty AgeProperty =
            DependencyProperty.Register(
            "Age",  //Must be the same name as the property created above
            typeof(int), //Must be the same type as the property created above
            typeof(Person), //Must be the same as the owner class
            new UIPropertyMetadata(
                0,  //default value, must be of the same type as the property
                new PropertyChangedCallback((s, e) =>  //A callback that gets executed when the property changed
                {
                    var source = s as Person;
                    s.DOB_Year = DateTime.Now.Year - s.Age; 
                })));
