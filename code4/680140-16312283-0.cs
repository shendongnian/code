        public List<int> GetChildren(int id)
        {
            var nodes = GetRadio();
            var parent = nodes.Single(n => n.NodeID == id);
            var children = nodes.Where(n => n.SourceRadioID == parent.RadioID);
            return children.Select(n => n.NodeID);
        }
