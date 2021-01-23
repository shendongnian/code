    // This is the 'strategy' in your case
    public interface IInteraction
    {
        void Do();
    }
    public class GameObject
    {
        // Here is your list of interactions - you can do whatever you want with it.
        public List<IInteraction> Interactions { get; set; }
    }
    // Here is an interaction
    public class Shake : IInteraction
    {
        public void Do()
        {
            ....
        }
    }
