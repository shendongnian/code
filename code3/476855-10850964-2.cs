    public class ExpandButtonAction : TargetedTriggerAction<FrameworkElement>
    {
        #region Invoke
    
        protected override void Invoke(object parameter)
        {
            RoutedEventArgs eventArgs = (RoutedEventArgs) parameter;
            Button bsender = eventArgs.OriginalSource as Button;
            var row = DataGridRow.GetRowContainingElement(eventArgs.OriginalSource as FrameworkElement);
            if (row.DetailsVisibility == Visibility.Visible)
            {
                row.DetailsVisibility = Visibility.Collapsed;
            }
            else
            {
                row.DetailsVisibility = Visibility.Visible;
            }
        }
    
        #endregion
    }
