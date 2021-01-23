    using System.Text.RegularExpressions;
    using System.Windows.Controls;
    using System.Windows.Input;
    using System.Windows.Interactivity;
    
    /// <summary>
    /// UI behavior for <see cref="TextBox"/> to filter input text with special RegularExpression.
    /// </summary>
    public class TextBoxInputRegexFilterBehavior : Behavior<TextBox>
    {
        private Regex regex;
    
        private string originalText;
        private int originalSelectionStart;
        private int originalSelectionLength;
    
        /// <summary>
        /// Gets or sets RegularExpression.
        /// </summary>
        public string RegularExpression 
        {
            get
            {
                return this.regex.ToString();
            } 
    
            set 
            {
                if (string.IsNullOrEmpty(value))
                {
                    this.regex = null;
                }
                else
                {
                    this.regex = new Regex(value);
                }
            } 
        }
    
        /// <inheritdoc/>
        protected override void OnAttached()
        {
            base.OnAttached();
    
            this.AssociatedObject.TextInputStart += this.AssociatedObjectTextInputStart;
            this.AssociatedObject.TextChanged += this.AssociatedObjectTextChanged;
        }
    
        /// <inheritdoc/>
        protected override void OnDetaching()
        {
            base.OnDetaching();
    
            this.AssociatedObject.TextInputStart -= this.AssociatedObjectTextInputStart;
            this.AssociatedObject.TextChanged -= this.AssociatedObjectTextChanged;
        }
    
        private void AssociatedObjectTextChanged(object sender, TextChangedEventArgs e)
        {
            if (this.originalText != null)
            {
                string text = this.originalText;
                this.originalText = null;
                this.AssociatedObject.Text = text;
                this.AssociatedObject.Select(this.originalSelectionStart, this.originalSelectionLength);
            }
        }
    
        private void AssociatedObjectTextInputStart(object sender, TextCompositionEventArgs e)
        {
            if (this.regex != null && e.Text != null && !(e.Text.Length == 1 && char.IsControl(e.Text[0])))
            {
                if (!this.regex.IsMatch(e.Text))
                {
                    this.originalText = this.AssociatedObject.Text;
                    this.originalSelectionStart = this.AssociatedObject.SelectionStart;
                    this.originalSelectionLength = this.AssociatedObject.SelectionLength;
                }
            }
        }
    }
