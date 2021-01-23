        void outlookInstance_ContextMenuClose(OlContextMenu ContextMenu)
        {
            if (ContextMenu == OlContextMenu.olItemContextMenu)
            {
                ContextIndexButton.Click -= new _CommandBarButtonEvents_ClickEventHandler(<your method>);
                ContextIndexButton = null;
            }
        }
