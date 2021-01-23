    public interface IDeepClonable 
    { 
        void DeepClone(IDeepClonable other); 
    } 
    
    public class ClassA : IDeepClonable 
    { 
        void DeepClone(IDeepClonable other)
        {
             // just to be sure ....
             if (other is ClassA) 
             {
                 var o = (ClassA)other;
                 this.A = o.A; 
             }
        } 
    } 
