    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    static class Program
    {
        static void Main(string[] args)
        {
            Parent p = new Parent();
            p.child = new Child();
            p.child.GrandChildren = new List<GrandChild>();
            p.child.GrandChildren.Add(new GrandChild { pet = new Pet() });
            p.child.GrandChildren.First().pet.Toys = new List<Toy>();
            p.child.GrandChildren.First().pet.Toys.Add(new Toy { ToyName = "Test" });
            byte[] result = Serialize(p);
            Parent backAgain = Deserialize(result);
        }
        public static System.Runtime.Serialization.Formatters.Binary.BinaryFormatter BinarySerializer = new System.Runtime.Serialization.Formatters.Binary.BinaryFormatter(); 
        public static byte[] Serialize(Parent p) 
        { 
            using (var ms = new System.IO.MemoryStream()) 
            {
                BinarySerializer.Serialize(ms, p); 
                return ms.ToArray(); 
            } 
        }
        public static Parent Deserialize( byte[] data)
        {
            using (var ms = new System.IO.MemoryStream(data))
            {
                return (Parent)BinarySerializer.Deserialize(ms);
            }
        }
    }
    [Serializable]
    public class Parent
    {
        public virtual Child child { get; set; }
    }
    [Serializable]
    public class Child
    {
        public virtual ICollection<GrandChild> GrandChildren { get; set; }
    }
    [Serializable]
    public class GrandChild
    {
        public virtual Pet pet { get; set; }
    }
    [Serializable]
    public class Pet : System.Runtime.Serialization.ISerializable
    {
        public Pet() { }
        // called when de-serializing (binary)
        protected Pet(System.Runtime.Serialization.SerializationInfo info,
                      System.Runtime.Serialization.StreamingContext context) 
        {
            Toys = new List<Toy>(); 
            int counter = info.GetInt32("ListCount");
            for (int index = 0; index < counter; index++)
            {
                Toys.Add((Toy)info.GetValue(string.Format("Toy{0}",index.ToString()),typeof(Toy)));
            }
        }
        // called when serializing (binary)
        public void GetObjectData(System.Runtime.Serialization.SerializationInfo info, 
                                  System.Runtime.Serialization.StreamingContext context)
        {
            info.AddValue("ListCount", Toys.Count);
            for (int index = 0; index < Toys.Count; index++)
            {
                info.AddValue(string.Format("Toy{0}", index.ToString()), Toys[index], typeof(Toy));
            }
        }
        public virtual IList<Toy> Toys { get; set; }
    }
    [Serializable]
    public class Toy
    {
        public string ToyName { get; set; }
    }
    
