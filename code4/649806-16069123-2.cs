    class Basic 
    {
        public void SelectAll() { Console.WriteLine("SelectAll"); }
    }
    
    class ChildWithUpdate : Basic
    {
        public void Update() { Console.WriteLine("Update"); }
    }
    
    class ChildWithArchive : Basic
    {
        public void Archive() { Console.WriteLine("Archive"); }
    }
