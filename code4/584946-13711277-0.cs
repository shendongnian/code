        private void GridPreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var parent = FindVisualParent<StackPanel>((DependencyObject)e.OriginalSource);
            if (parent != null && parent.Tag == "IgnoreClickPanel")
            {
                //ignore previewclicks from these controls
            }
            else
            {
                //prism eventaggregator will notify all user controls which care about this
                eventAggregator.GetEvent<MouseDownEvent>().Publish(true);
            }
            e.Handled = false;
        }
