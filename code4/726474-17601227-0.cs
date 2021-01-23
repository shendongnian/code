    if ( lstDinner.SelectedItem == null)
    {
      output = _imageInserter.InsertImage(imageName, lstToys.SelectedItem.ToString());
      PopupToysImage.IsOpen = true;
      lstDinner.Databind();
    }
