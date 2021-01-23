     protected override void OnQueryContinueDrag(QueryContinueDragEventArgs e)
        {
            if (!e.KeyStates.HasFlag(DragDropKeyStates.LeftMouseButton))
            {
                 e.Action = DragAction.Cancel;
            }
            else
            {
                e.Action = DragAction.Continue;
            }
        }
