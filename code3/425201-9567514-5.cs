        private void PreviewKeyDownHandler(object sender, KeyEventArgs e)
        {            
            RichTextBox rtb = sender as RichTextBox;
            if (rtb != null)
            {
                if (e.Key == Key.Down)
                {
                    // if there is another line below current
                    if (rtb.CaretPosition.GetLineStartPosition(0) != rtb.CaretPosition.GetLineStartPosition(1))
                    {
                        // find the FlowDocumentView through reflection
                        FrameworkElement flowDocumentView = GetFlowDocument(rtb);
                        // get the content bounds of the current line 
                        Rect currentLineBounds = rtb.CaretPosition.GetCharacterRect(LogicalDirection.Forward);
                        // move the caret down to next line
                        EditingCommands.MoveDownByLine.Execute(null, rtb);
                        // get the content bounds of the new line
                        Rect nextLineBounds = rtb.CaretPosition.GetCharacterRect(LogicalDirection.Forward);
                        // get the offset the document
                        double currentDocumentOffset = flowDocumentView.Margin.Top;
                        // add the height of the previous line to the offset 
                        // the character rect of a line doesn't include the baseline offset so the actual height of line has to be determined
                        // from the difference in the offset between the tops of the character rects of the consecutive lines
                        flowDocumentView.Margin = new Thickness { Top = currentDocumentOffset + currentLineBounds.Top - nextLineBounds.Top };
                    }
                    // prevent default behavior
                    e.Handled = true;
                }
                if (e.Key == Key.Up)
                {
                    if (rtb.CaretPosition.GetLineStartPosition(0) != rtb.CaretPosition.GetLineStartPosition(-1))
                    {
                        FrameworkElement flowDocumentView = GetFlowDocument(rtb);
                        Rect currentLineBounds = rtb.CaretPosition.GetCharacterRect(LogicalDirection.Forward);
                        EditingCommands.MoveUpByLine.Execute(null, rtb);
                        Rect nextLineBounds = rtb.CaretPosition.GetCharacterRect(LogicalDirection.Forward);
                        double currentDocumentOffset = flowDocumentView.Margin.Top;
                        flowDocumentView.Margin = new Thickness { Top = currentDocumentOffset + currentLineBounds.Top - nextLineBounds.Top };
                    }
                    e.Handled = true;
                }
            }
        }
        protected FrameworkElement GetFlowDocument(RichTextBox textBox)
        {
            FrameworkElement flowDocumentVisual =
              GetChildByTypeName(textBox, "FlowDocumentView") as FrameworkElement;
            return flowDocumentVisual;
        }
        protected DependencyObject GetChildByTypeName(DependencyObject dependencyObject, string name)
        {
            if (dependencyObject.GetType().Name == name)
            {
                return dependencyObject;
            }
            else
            {
                if (VisualTreeHelper.GetChildrenCount(dependencyObject) > 0)
                {
                    int childCount = VisualTreeHelper.GetChildrenCount(dependencyObject);
                    for (int idx = 0; idx < childCount; idx++)
                    {
                        var dp = GetChildByTypeName(VisualTreeHelper.GetChild(dependencyObject, idx), name);
                        if (dp != null)
                            return dp;
                    }
                    return null;
                }
                else
                {
                    return null;
                }
            }
        }
