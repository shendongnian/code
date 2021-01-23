    public override Object Clone()
    {
        object clonedObject = base.Clone();
        MaskTextColumn clonedColumn = clonedObject as MaskTextColumn;
        clonedColumn.PromptChar = this.PromptChar;
        // .. more property settings here
        return clonedColumn;
    }
