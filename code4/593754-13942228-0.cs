    private bool AtLeastOnePlatypusChecked()
    {
        return ((ckbx1.IsChecked.GetValueOrDefault()) ||
                (ckbx2.IsChecked.GetValueOrDefault()) ||
                (ckbx3.IsChecked.GetValueOrDefault()) ||
                (ckbx4.IsChecked.GetValueOrDefault()));
    }
