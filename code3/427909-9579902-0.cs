    public class MultilineAutocompleteBox : AutoCompleteBox
    {
        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
                this.Text = string.Format("{0}\n", this.Text);
    
            base.OnKeyDown(e);
        }
    }
