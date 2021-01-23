    public class SettingsComponentAttributes : ComponentAttributes
    {
        public override ObjectResponse RespondToMouseDoubleClick(Canvas sender, CanvasMouseEvent e)
        {
            ((SettingsComponent)Owner).ShowSettingsGui();
            return ObjectResponse.handled;
        }
    }
