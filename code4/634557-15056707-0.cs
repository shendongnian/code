    // my original object
    class SavedObject
    {
        public string Data{get;set}
    }
    // needed to add a field for last edit
    class SavedObject2
    {
        public DateTime LastEdit{get;set;}
    
        public SavedObject2(SavedObject so){}
    }
    // need a small restructure so we can now have multiple datas
    // 'data' is now obsolete
    class SavedObject3
    {
        public List<string> DataList{get;set;}
        public SavedObject3(SavedObject2 so){}
    }
