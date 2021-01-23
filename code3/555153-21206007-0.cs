    /// <summary>
    /// Own handler. This event is raised when something happens during DragDrop operation (user presses Mouse button or Keyboard button...)
    /// Necessary to avoid canceling DragDrop on MouseMiddleButon on certain PCs.
    /// Overrides default handler, that interrupts DragDrop on MouseMiddleButon or MouseRightButton down.
    /// </summary>
    /// <param name="source"></param>
    /// <param name="e"></param>
    private void QueryContinueDragHandler(Object source, QueryContinueDragEventArgs e)
    {
        e.Handled = true;
            // if ESC
            if (e.EscapePressed)
            {
                //  -->  cancel DragDrop
                e.Action = DragAction.Cancel;
                
                return;
            }
            // if LB
            if (e.KeyStates.HasFlag(DragDropKeyStates.LeftMouseButton))
            {
                //  -->  continue dragging
                e.Action = DragAction.Continue;
            }
            // if !LB (user released LeftMouseButton)
            else
            {
                // and if mouse is inside canvas
                if (_isMouseOverCanvas)
                {
                    //  -->  execute Drop
                    e.Action = DragAction.Drop;
                }
                else
                {
                    //  -->  cancel Drop 
                    e.Action = DragAction.Cancel;                    
                }
                return;
            }
            // if MB
            if (e.KeyStates.HasFlag(DragDropKeyStates.MiddleMouseButton))
            {
                //  -->  continue dragging
                e.Action = DragAction.Continue;
            }    
    }
