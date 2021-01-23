    public class UpperCaseAction : TriggerAction<TextBox>
    {
        protected override void Invoke(object parameter)
        {
            var selectionStart = AssociatedObject.SelectionStart;
            var selectionLength = AssociatedObject.SelectionLength;
            AssociatedObject.Text = AssociatedObject.Text.ToUpper();
            AssociatedObject.SelectionStart = selectionStart;
            AssociatedObject.SelectionLength = selectionLength;
        }
    }
