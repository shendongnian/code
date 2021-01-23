    private void _timerCallback(object state)
    {
        _parentForm.Invoke((Action) delegate {
            try
            {
                if (HasUserCancelled)
                {
                    Cancelled?.Invoke(this, EventArgs.Empty);
                }
            }
            catch (Exception)
            {
                // Swallow
            }
        });
    }
