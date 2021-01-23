    interface IParentInterface
    {
       int FirstProperty {get;set;}
       void OnChange();
    }
    interface IChildInterface: IParentInterface
    {
       string SecondProperty {get;set;}
    }
    class InterfaceInheritanceGoodness: IChildInterface
    {
       public int FirstProperty { get; set; }
       
       public string SecondProperty { get; set; }
 
       public void OnChange()
       {
           throw new NotImplementedException();
       }
    }
