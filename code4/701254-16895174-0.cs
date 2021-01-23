    public class ButtonAttribute : ActionMethodSelectorAttribute
    {
        public string ButtonName { get; set; }
        public override bool IsValidForRequest(
            ControllerContext controllerContext, 
            System.Reflection.MethodInfo methodInfo)
        {
            return controllerContext.Controller.ValueProvider
                .GetValue(ButtonName) != null;
        }
        public ButtonAttribute(string buttonName)
        {
            ButtonName = buttonName;
        }
    }
