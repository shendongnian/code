    void ProcessInput(Message message)
    {
        // Code sample which raises just the key down event
        switch (rawInput.keyboard.Message)
        {
            case (uint) BIFWin32.WindowMessage.WM_KEYDOWN:
            {
                if (BIFDeviceCollections.MouseCollection[ID].MouseFocusElement is IMultiKeyboardEvents)
                {
                    IMultiKeyboardEvents widget = 
                    (IMultiKeyboardEvent)BIFDeviceCollections.MouseCollection[ID].MouseFocusedElement;
                    widget.OnMultiKeyDown(eventArgs);
                }
            }
        }
    }
