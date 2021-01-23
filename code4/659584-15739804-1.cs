    internal class TabControlDesigner : ParentControlDesigner
    {
        public override void InitializeNewComponent(IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);
            try
            {
                this.addingOnInitialize = true;
                this.OnAdd((object) this, EventArgs.Empty);
                this.OnAdd((object) this, EventArgs.Empty);
                ...
