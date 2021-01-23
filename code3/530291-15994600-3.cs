    public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
    {
        if (args.Length != 0)
        {
            result = null;
            return false;
        }
        result = _xml.Elements(binder.Name);
        return true;
    }
