    public class MaskVisibilityBehavior : Behavior<MaskedTextBox> {
      private FrameworkElement _contentPresenter;
    
      protected override void OnAttached() {
        base.OnAttached();
        AssociatedObject.Loaded += (sender, args) => {
          _contentPresenter = AssociatedObject.Template.FindName("PART_ContentHost", AssociatedObject) as FrameworkElement;
          if (_contentPresenter == null)
            throw new InvalidCastException();
          AssociatedObject.TextChanged += OnTextChanged;
          AssociatedObject.GotFocus += OnGotFocus;
          AssociatedObject.LostFocus += OnLostFocus;
          UpdateMaskVisibility();
        };
      }
    
      protected override void OnDetaching() {
        AssociatedObject.TextChanged -= OnTextChanged;
        AssociatedObject.GotFocus -= OnGotFocus;
        AssociatedObject.LostFocus -= OnLostFocus;
        base.OnDetaching();
      }
    
      private void OnLostFocus(object sender, RoutedEventArgs routedEventArgs) {
        UpdateMaskVisibility();
      }
    
      private void OnGotFocus(object sender, RoutedEventArgs routedEventArgs) {
        UpdateMaskVisibility();
      }
    
      private void OnTextChanged(object sender, TextChangedEventArgs textChangedEventArgs) {
        UpdateMaskVisibility();
      }
    
      private void UpdateMaskVisibility() {
        _contentPresenter.Visibility = AssociatedObject.MaskedTextProvider.AssignedEditPositionCount > 0 ||
                                        AssociatedObject.IsFocused
                                          ? Visibility.Visible
                                          : Visibility.Hidden;
      }
    }
