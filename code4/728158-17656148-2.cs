        try
        {
            if (windowPattern.Current.WindowInteractionState ==
                WindowInteractionState.ReadyForUserInteraction)
            {
                switch (visualState)
                {
                    case WindowVisualState.Maximized:
                        // Confirm that the element can be maximized 
                        if ((windowPattern.Current.CanMaximize) && 
                            !(windowPattern.Current.IsModal))
                        {
                            windowPattern.SetWindowVisualState(
                                WindowVisualState.Maximized);
                            // TODO: additional processing
                        }
                        break;
                    case WindowVisualState.Minimized:
                        // Confirm that the element can be minimized 
                        if ((windowPattern.Current.CanMinimize) &&
                            !(windowPattern.Current.IsModal))
                        {
                            windowPattern.SetWindowVisualState(
                                WindowVisualState.Minimized);
                            // TODO: additional processing
                        }
                        break;
                    case WindowVisualState.Normal:
                        windowPattern.SetWindowVisualState(
                            WindowVisualState.Normal);
                        break;
                    default:
                        windowPattern.SetWindowVisualState(
                            WindowVisualState.Normal);
                        // TODO: additional processing 
                        break;
                }
            }
        }
        catch (InvalidOperationException)
        {
            // object is not able to perform the requested action 
            return;
        }
    }
