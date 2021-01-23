    using ProtoBuf;
    using System;
    using System.Collections.Generic;
    using System.IO;
    static class Program
    {
        public static void Main()
        {
            using (var outputStream = File.Create("foo.bin"))
            {
                var obj = new QueueList { };
                obj.ItemsList.Add(new QueueItem { Email = "hi@world.com" });
                Serializer.Serialize(outputStream, obj);
            }
            using (var inputStream = File.OpenRead("foo.bin"))
            {
                var obj = Serializer.Deserialize<QueueList>(inputStream);
                Console.WriteLine(obj.ItemsList.Count); // 1
                Console.WriteLine(obj.ItemsList[0].Email); // hi@world.com
            }
        }
    }
    [Serializable]
    [ProtoContract]
    public class QueueList : SafeList<QueueItem>
    {
    
    }
    
    [ProtoContract]
    [ProtoInclude(1, typeof(SafeList<QueueItem>))]
    public class SafeLock {}
    
    [Serializable]
    [ProtoContract]
    [ProtoInclude(2, typeof(QueueList))]
    public class SafeList<T> : SafeLock
    {
        [ProtoMember(1)]
        public readonly List<T> ItemsList = new List<T>();
    }
    
    [Serializable]
    [ProtoContract]
    public class QueueItem
    {
        [ProtoMember(1)]
        public string SessionId { get; set; }
        [ProtoMember(2)]
        public string Email { get; set; }
        [ProtoMember(3)]
        public string Ip { get; set; }
    }
