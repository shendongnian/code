        public void AddChild(T childNode)
        {
            if(this.Children == null)
            {
               this.Children = new List<Node<T>>();
            }
            this.Children.Add(new Node<T>(childNode));
        }
