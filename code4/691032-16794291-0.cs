        protected virtual void OnDragOver(SW.DragEventArgs args)
        {
            foreach (SW.DragEventHandler handler in _dragOver)
            {
                handler(this, args);
                if (args.Handled)
                {
                    return;
                }
            }
            OnDragEvent(args);
        }
        protected virtual void OnDragEvent(SW.DragEventArgs args)
        {
            SW.DragDropEffects effects = args.AllowedEffects;
            ///removed for clarity
            if (!args.Handled && effects != args.AllowedEffects)
            {
                args.Effects = effects;  // revert back to args.AllowedEffects
                args.Handled = true;
            }
        }
