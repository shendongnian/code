    public abstract class NodeAbstract
    {
       abstract NodeAbstract Left {get;set:}
       abstract NodeAbstract Right {get;set:}
       .... 
       ....
    }
    
    public class NodeConcrete : NodeAbstract
    {
       .... 
       //implementation
    }
