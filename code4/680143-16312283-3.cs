        public List<int> GetChildren(int id)
        {
            var nodes = GetRadio();
            var parent = nodes.Single(n => n.NodeID == id);
            var children = nodes.Where(n => n.SourceRadioID == parent.RadioID).Select(n => n.NodeID);
            return children.Union(children.SelectMany(GetChildren)).ToList();
        }
