            var fileName = String.Format("WmDev_{0:}.jpg", DateTime.Now.Ticks);
            WriteableBitmap bmpCurrentScreenImage = new WriteableBitmap((int)this.ActualWidth, (int)this.ActualHeight);
            bmpCurrentScreenImage.Render(LayoutRoot, new MatrixTransform());
            bmpCurrentScreenImage.Invalidate();
            SaveToMediaLibrary(bmpCurrentScreenImage, fileName, 100);
            MessageBox.Show("Captured image " + fileName + " Saved Sucessfully", "WmDev Capture Screen", MessageBoxButton.OK);
            string currentFileName = fileName;
        }
