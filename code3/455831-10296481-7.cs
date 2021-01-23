    internal class ClientGameObject : GameObject
    {
        public override void SetPosition()
        {
            Console.WriteLine("ClientGameObject.SetPosition Before");
            base.SetPosition();
            Console.WriteLine("ClientGameObject.SetPosition After");
        }
    }
    internal static class Program
    {
        static void Main(string[] args)
        {
            GameObject.Factory += () => new ClientGameObject();
            Game.Start();
        }
    }
