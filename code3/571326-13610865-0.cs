     _updateIfWidthChangedDispacherO= _ownerTextBox.Dispatcher.BeginInvoke((Action)(() =>
            {
                updateIfWidthChanged();
            }),
            DispatcherPriority.ApplicationIdle);
