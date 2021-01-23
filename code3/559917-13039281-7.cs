    public class OtherAction : TriggerAction<TextBox>
    {
        Random test = new Random();
        protected override void Invoke(object parameter)
        {
            AssociatedObject.FontSize = test.Next(9, 13);
        }
    }
