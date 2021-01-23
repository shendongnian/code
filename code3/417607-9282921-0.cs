    public interface ITerminal<T> where T : IBay
    {
        // Properties
        int Id {get;set;}
        string Name {get;set;}
        IList<T> Bays {get;}
    }
    public Terminal : ITerminal<Bay>
    {
         private List<Bay> bays = new List<Bay>();
         IList<Bay> Bays { get { return bays; } }
         // ...
         public Terminal()
         {
             bays.Add(new Bay { //...
