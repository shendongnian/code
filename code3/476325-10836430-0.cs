    TextCompositionEventArgs args = new TextCompositionEventArgs(
        InputManager.Current.PrimaryKeyboardDevice,
        new TextComposition(InputManager.Current, txtBox, "Test text")
    );
    args.RoutedEvent = TextCompositionManager.PreviewTextInputEvent;
    txtBox.RaiseEvent(args);
    args = new TextCompositionEventArgs(
        InputManager.Current.PrimaryKeyboardDevice,
        new TextComposition(InputManager.Current, txtBox, "Test text")
    );
    args.RoutedEvent = TextCompositionManager.TextInputEvent;
    txtBox.RaiseEvent(args);
