        private void nudSeconds_ValueChanged(object sender, EventArgs e)
        {
            intervalChanged();
        }
        private void nudMilliseconds_ValueChanged(object sender, EventArgs e)
        {
            intervalChanged();
        }
        private bool intervalUpdating = false;
        private void intervalChanged()
        {
            if (intervalUpdating)
            {
                return;
            }
            intervalUpdating = true;
            if (nudMilliseconds.Value >= 1000)
            {
                var val = (int)nudMilliseconds.Value / 1000;
                nudSeconds.Value += val;
                nudMilliseconds.Value = (nudMilliseconds.Value - (val * 1000));
            }
            if (nudSeconds.Value >= 60)
            {
                var val = (int)nudSeconds.Value / 60;
                nudMinutes.Value += val;
                nudSeconds.Value = (nudSeconds.Value - (val * 60));
            }
            intervalUpdating = false;
        }
