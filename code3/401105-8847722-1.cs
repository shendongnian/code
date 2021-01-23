    public class CustomPicker : TimePicker
    {
        public void ClickTemplateButton()
        {
            Button button = (GetTemplateChild("DateTimeButton") as Button);
            ButtonAutomationPeer peer = new ButtonAutomationPeer(button);
            IInvokeProvider provider = (peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider);
            provider.Invoke();
        } 
    }
