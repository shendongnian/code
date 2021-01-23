    public class RebindOnTextChanged : Behavior<TextBox>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            this.AssociatedObject.TextChanged += this.TextChanged;
        }
        protected override void OnDetaching()
        {
            base.OnDetaching();
            this.AssociatedObject.TextChanged -= this.TextChanged;
        }
        private void TextChanged(object sender, TextChangedEventArgs e)
        {
            var bindingExpression = this.AssociatedObject.GetBindingExpression(TextBox.TextProperty);
            if (bindingExpression != null)
            {
                bindingExpression.UpdateSource();
            }
        } 
    }      
