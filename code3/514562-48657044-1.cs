    public class MultiDesigner : ControlDesigner
    {
        public MultiDesigner()
        {
           
        }
        public override void InitializeNewComponent(IDictionary defaultValues)
        {
            base.InitializeNewComponent(defaultValues);
            ICommonControl control = this.Component as ICommonControl;
            control.Text = control.Tag.ToString();
        }
    }
