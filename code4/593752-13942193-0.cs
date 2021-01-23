     private bool AtLeastOnePlatypusChecked()
     {
          return ((ckbx1.IsChecked ?? false) ||
          (ckbx2.IsChecked ?? false) ||
          (ckbx3.IsChecked ?? false) ||
          (ckbx4.IsChecked ?? false));
     }
