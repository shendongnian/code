    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Web.Script.Serialization;
    
    namespace JSONTest
    {
        class Program
        {
            static void Main(string[] args)
            {
                Channel c = new Channel();
                c.Guid = Guid.NewGuid();
                c.Parent = Guid.NewGuid();
                c.Title = "FooBar";
                c.Children = new List<Channel>();
    
                Channel a = new Channel();
                Channel b = new Channel();
                
                a.Guid = Guid.NewGuid();
                b.Guid = Guid.NewGuid();
    
                a.Parent = Guid.NewGuid();
                b.Parent = Guid.NewGuid();
    
                a.Title = "FooBar_A";
                b.Title = "FooBar_B";
    
                c.Children.Add(a);
                c.Children.Add(b);
    
                /* Serialization happens here!! */
                JavaScriptSerializer serializer = new JavaScriptSerializer();
                string result = serializer.Serialize(c);
                Console.WriteLine(result);
                Console.Read();
            }
        }
    
        public class Channel
        {
            public Guid Guid { get; set; }
            public string Title { get; set; }
    
            /* GOT A LOT MORE PROPERTIES IN THIS SPACE */
    
            public Guid Parent { get; set; }
            public List<Channel> Children { get; set; }
        }
    }
