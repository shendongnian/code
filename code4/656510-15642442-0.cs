    interface iMyTree
    {
        int MyTreeID {get; set;}
        string MyTreePame {get; set;}
        object MyTreeParent {get; set;}
        string MyTreeText  {get; set;}
    }
    
    class AnyTree : iMyTree
    {
         //any properties
 
         //implements iMyTree
    }
