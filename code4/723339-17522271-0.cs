    OpenFileDialog op = new OpenFileDialog();
    string folderpath = System.IO.Directory.GetParent(Environment.CurrentDirectory).Parent.FullName + "\\ContactImages\\";
    op.Title = "Select a picture";
    op.Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
                "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
                "Portable Network Graphic (*.png)|*.png";
    bool? myResult;
    myResult = op.ShowDialog();
    if (myResult != null && myResult == true)
    {
      imgContactImage.Source = new BitmapImage(new Uri(op.FileName));
      if (!Directory.Exists(folderpath))
      {
         Directory.CreateDirectory(folderpath);
      }
      string filePath = folderpath + System.IO.Path.GetFileName(op.FileName);
      System.IO.File.Copy(op.FileName, filePath, true);
     }
