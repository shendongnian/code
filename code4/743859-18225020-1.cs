    private bool ButtonSmartTag(ITextView view)
        {
            foreach (ISmartTagSession s in _broke.GetSessions(view))
            {
                var wpfTextView = (IWpfTextView)view;               
                var adornmentLayer = wpfTextView.GetAdornmentLayer("SmartTag");
                foreach (var alement in adornmentLayer.Elements)
                {
                    adornmentLayer.RemoveAllAdornments();
                    var line = view.GetTextViewLineContainingBufferPosition(_view.Caret.Position.BufferPosition);
                    alement.VisualSpan, "butRe", but, null);
                    var mb = new ReButtonMenu();
                    mb.Margin = new Thickness(0, line.Top, 0, 0);
                    adornmentLayer.AddAdornment(AdornmentPositioningBehavior.TextRelative, alement.VisualSpan, "butRe", mb, null);
                }
            }
            return false;
        }
