    public class BaseClass 
    {
       public bool Garbage {get;set}
    }
    
    //somewhere you have a collection of all artifacts to draw (children of BaseClass) 
    Lis<BaseClass> stuffToDraw = new List<BaseClass){....}
    
    //and somewhere in the framewrok you have a method to draw them  
    
    public void Paint(...)
    {
         stuffToDraw.ForEach(stuff=>
         {
             if(stuff.Garbage) return; 
             stuff.Draw(....); //call of overriden virtual method
         });
    }
