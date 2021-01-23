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
       int FirstProperty
       {
           get 
           {
           throw new NotImplementedException();
           }
           set
           {
           throw new NotImplementedException();
           }
       }
       
       string SecondProperty
       {
           get 
           {
           throw new NotImplementedException();
           }
           set
           {
           throw new NotImplementedException();
           }
       }
 
       void OnChange()
       {
           throw new NotImplementedException();
       }
    }
