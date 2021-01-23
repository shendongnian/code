    public void RemoveButtonClickHandlers(UIElementCollection elements)
    {
        foreach (var button in elements.OfType<Button>())
        {
            try
            {
                var handlers = typeof(UIElement).GetProperty("EventHandlersStore", BindingFlags.Instance | BindingFlags.NonPublic).GetValue(button, null);
                if (handlers != null)
                {
                    var clickEvents = (RoutedEventHandlerInfo[])handlers.GetType()
                    .GetMethod("GetRoutedEventHandlers", BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic)
                    .Invoke(handlers, new object[] { ButtonBase.ClickEvent });
                    foreach (var clickEvent in clickEvents)
                    {
                        button.Click -= (RoutedEventHandler)clickEvent.Handler;
                    }
                }
            }
            catch (Exception ex)
            {
                // :(
            }
        }
    }
