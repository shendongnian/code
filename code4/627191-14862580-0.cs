        class Node
        {
            public Guid Id { get; set; }
            public IEnumerable<Node> Children { get; set; }
            public string Description { get; set; }
        }
