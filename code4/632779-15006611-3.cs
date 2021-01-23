    public Parent GetParent(int ID)
    {
         var myParent = new Parent();
         parent.InitProperties();
         return myParent;
    }
    
    public Parent GetChild(int ID)
    {
         var  child= new Child();
         child.InitProperties();
         return child;
    }
