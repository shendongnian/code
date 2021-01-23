    public override object Clone()
    {
        object objReturn = base.Clone();
        ((MyTreeNode)objReturn).Foo = this.Foo;
        return objReturn;
    }
