    protected virtual void OnByteArrayChanged(DependencyPropertyChangedEventArgs e)
      {
         try
         {
            // PropertyChanged method
            BitmapImage bmpi = new BitmapImage();
            bmpi.BeginInit();
            bmpi.StreamSource = new MemoryStream(ByteArray);
            bmpi.EndInit();
            System.Windows.Controls.Image image1 = (get my image in my xaml);
            image1.Source = bmpi;
         }catch (Exception){...}
      }
