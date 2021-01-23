    public override bool TryGetMember(GetMemberBinder binder, out object result)
    {
        result = null;
        var att = _root.Attributes().FirstOrDefault(x => x.Name.LocalName == binder.Name);
        if (att != null)
        {
            result = att.Value;
            return true;
        }
        var nodes = _root.Descendants().Where(e => e.Name.LocalName == binder.Name);
        if (nodes.Count() > 1)
        {
            result = nodes.Select(n => n.HasElements ? (object)new DynamicXml(n) : n.Value).ToList();
            return true;
        }
        var node = nodes.FirstOrDefault(e => e.Name.LocalName == binder.Name);
        if (node != null)
        {
            result = node.HasElements || node.HasAttributes ? (object)new DynamicXml(node) : node.Value;
            return true;
        }
        return true;
    }
