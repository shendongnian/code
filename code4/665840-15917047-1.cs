    public static void RightClick(this AutomationElement element)
        {
         var ev = new MouseButtonEventArgs(Mouse.PrimaryDevice, 0, MouseButton.Right);
         ev.RoutedEvent = Mouse.MouseDownEvent;
         this.OnMouseDown(ev);
        }
