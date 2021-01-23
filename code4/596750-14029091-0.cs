    public class MathRichTextbox : RichTextBox
    {
        public MathRichTextbox()
        {
            this.PreviewKeyDown += MathRichTextbox_PreviewKeyDown;
        }
        void MathRichTextbox_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Digit expr = null;
            switch (e.Key)
            {
                case Key.Left:
                    expr = findAdjacentMathDigits(LogicalDirection.Backward);
                    break;
                case Key.Right:
                    expr = findAdjacentMathDigits(LogicalDirection.Forward);                    
                    break;
            }
            if (expr != null)
                this.Dispatcher.BeginInvoke(
                    new ThreadStart(() => expr.FocusBase()),
                    System.Windows.Threading.DispatcherPriority.Input, null);
        }
        private Digit findAdjacentMathDigits(LogicalDirection direction)
        {
            Digit expr = null;
            if (Selection.Text.Length == 0)
            {
                DependencyObject dpObj = CaretPosition.GetAdjacentElement(
                    direction);
                // is it contained in BlockUIContainer?
                expr = CaretPosition.GetAdjacentElement(
                    direction) as Digit;
                // is it onctained in a InlineUIContainer?
                if (expr == null)
                {
                    InlineUIContainer uiWrapper =
                        CaretPosition.GetAdjacentElement(
                        direction) as InlineUIContainer;
                    if (uiWrapper != null)
                        expr = uiWrapper.Child as Digit;
                }
            }
            return expr;
        }
    }
