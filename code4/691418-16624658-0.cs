    [TemplatePart(Name = PartButton, Type = typeof(ButtonBase))]
    public class MyControl : Control
    {
        private const string PartButton = "PART_Button";
        private ButtonBase buttonPart;
    
        public override void OnApplyTemplate()
        {
            base.OnApplyTemplate();
    
            this.buttonPart = GetTemplateChild(PartButton) as ButtonBase;
        }
    }
