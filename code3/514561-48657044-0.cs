    public class MultiDesigner : ControlDesigner
    {
        ICommonControl control = null;
        public MultiDesigner()
        {
           
        }
        public override void Initialize(IComponent component)
        {
            base.Initialize(component);
            this.control = component as ICommonControl;
        }
        public override void InitializeNewComponent(IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);
            this.control.Text = this.control.Tag.ToString();
        }
    }
