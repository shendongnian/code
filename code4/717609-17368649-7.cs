     //Variable to track GripInterationStatus
     bool isGripinInteraction = false;
    
            private void OnQuery(object sender, QueryInteractionStatusEventArgs handPointerEventArgs)
            {
                
                //If a grip detected change the cursor image to grip
                if (handPointerEventArgs.HandPointer.HandEventType == HandEventType.Grip)
                {
                    isGripinInteraction = true;
                    handPointerEventArgs.IsInGripInteraction = true;
                }
    
               //If Grip Release detected change the cursor image to open
                else if (handPointerEventArgs.HandPointer.HandEventType == HandEventType.GripRelease)
                {
                    isGripinInteraction = false;
                    handPointerEventArgs.IsInGripInteraction = false;
                }
    
                //If no change in state do not change the cursor
                else if (handPointerEventArgs.HandPointer.HandEventType == HandEventType.None)
                {
                    handPointerEventArgs.IsInGripInteraction = isGripinInteraction;
                }
    
                handPointerEventArgs.Handled = true;
            }
