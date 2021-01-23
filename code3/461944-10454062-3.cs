    var obj = new Node {
        Name = "one",
        Child = new Node {
            Name = "two",
            Child = new Node {
                Name = "three"
            }
        }
    };
    var txt1 = SerializeObject(obj, 1);
    var txt2 = SerializeObject(obj, 2);
    public class Node
    {
        public string Name { get; set; }
        public Node Child { get; set; }
    }
