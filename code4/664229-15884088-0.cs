    private void HitTestHand(HandPosition hand)
    {
        // quick fix to null pointer exception on exit.
        if (Application.Current.MainWindow == null)
            return;
        Point pt = new Point(hand.X, hand.Y);
        IInputElement input = Application.Current.MainWindow.InputHitTest(pt);
        
        if (hand.CurrentElement != input)
        {
            var inputObject = input as DependencyObject;
            var currentObject = hand.CurrentElement as DependencyObject;
            // If the new input is a child of the current element then don't fire the leave event.
            // It will be fired later when the current input moves to the parent of the current element.
            if (hand.CurrentElement != null && Utility.IsElementChild(currentObject, inputObject) == false)
            {
                // Raise the HandLeaveEvent on the CurrentElement, which at this point is the previous element the hand was over.
                hand.CurrentElement.RaiseEvent(new HandInputEventArgs(HoverDwellButton.HandLeaveEvent, hand.CurrentElement, hand));
            }
            // If the current element is the parent of the new input element then don't
            // raise the entered event as it has already been fired.
            if (input != null && Utility.IsElementChild(inputObject, currentObject) == false)
            {
                input.RaiseEvent(new HandInputEventArgs(HoverDwellButton.HandEnterEvent, input, hand));
            }
            hand.CurrentElement = input;
        }
        else if (hand.CurrentElement != null)
        {
            hand.CurrentElement.RaiseEvent(new HandInputEventArgs(HoverDwellButton.HandMoveEvent, hand.CurrentElement, hand));
        }
    }
