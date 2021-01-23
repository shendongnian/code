    static class Commons
    {
        internal static void Update(/*receive all necessary params*/) 
        { 
            /*execute and return result*/
        }
    
        internal static void Archive(/*receive all necessary params*/) 
        { 
            /*execute and return result*/
        }
    }
    
    class Basic 
    {
        public void SelectAll() { Console.WriteLine("SelectAll"); }
    }
    
    class ChildWithUpdate : Basic
    {
        public void Update() { Commons.Update(); }
    }
    
    class ChildWithArchive : Basic
    {
        public void Archive() { Commons.Archive(); }
    }
    
    class ChildWithUpdateAndArchive: Basic
    {
        public void Update() { Commons.Update(); }
        public void Archive() { Commons.Archive(); }
    }
