    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    
    [ProtoContract]
    class RootObject
    {
        [ProtoMember(1, AsReference = true)]
        public IContainer Container { get; set; }
    }
    
    [ProtoContract]
    [ProtoInclude(500, typeof(Basket))]
    public interface IContainer
    {
        [ProtoMember(2, OverwriteList = true, AsReference = true)]
        List<Banana> Bananas { get; set; }
    
        [ProtoMember(1, OverwriteList = true, AsReference = true)]
        List<IFruit> Fruits { get; set; }
    
    }
    
    [ProtoContract]
    public class Basket : IContainer
    {
        public List<Banana> Bananas { get; set; }
    
        public List<IFruit> Fruits { get; set; }
    
        public void AddBanana()
        {
            if (Bananas == null) Bananas = new List<Banana>();
            if (Fruits == null) Fruits = new List<IFruit>();
            var number = Bananas.Count;
            var newBanana = new Banana { Number = number, ContainedBy = this };
    
            // var lastBanana = Bananas[Bananas.Count - 1];
            // var index = Fruits.LastIndexOf(lastBanana);
    
            // Fruits.Insert(index + 1, newBanana);
    
            Fruits.Add(newBanana);
            Bananas.Add(newBanana);
        }
    
        public void DeleteBanana(Banana banana)
        {
            Bananas.Remove(banana);
            Fruits.Remove(banana);
            var n = 0;
            foreach (Banana b in Bananas)
            {
                b.Number = n++;
            }
        }
    }
    
    [ProtoContract]
    [ProtoInclude(600, typeof(Banana))]
    public interface IFruit
    {
        [ProtoMember(1, AsReference = true)]
        IContainer ContainedBy { get; set; }
    }
    
    [ProtoContract]
    public class Banana : IFruit
    {
        [ProtoMember(1)]
        public int Number { get; set; }
    
        public IContainer ContainedBy { get; set; }
    }
    
    
    static class Program
    {
        static void Main()
        {
            var basket = new Basket();
            var root = new RootObject { Container = basket };
            basket.AddBanana();
    
            var clone = Serializer.DeepClone(root);
            Console.WriteLine(clone.Container.Fruits.Count == 1); // true
            Console.WriteLine(clone.Container.Bananas.Count == 1); // true
            Console.WriteLine(ReferenceEquals(
                clone.Container.Bananas[0],
                clone.Container.Fruits[0])); // true
            Console.WriteLine(ReferenceEquals(
                clone.Container.Fruits[0].ContainedBy,
                clone.Container)); // true
        }
    }
