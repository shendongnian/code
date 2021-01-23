    public MyClass
    {
        public List<File> LoadedFiles{get; set;}
    }
    
    public ViewModelOne
    {
        public MyClass MyClassInstance {get; set;}
        public ViewModelOne(MyClass myclass)
        {
            MyClassInstance = myclass
        }
    }
    
    public ViewModelTwo
    {
        public MyClass MyClassInstance {get; set;}
        public ViewModelTwo(MyClass myclass)
        {
            MyClassInstance = myclass
        }
    }
