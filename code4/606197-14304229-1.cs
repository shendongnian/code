    //Event raised on ImageSource property changed while Backgroundwoker in MainWindow class:
        void binding_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            MyProject.ImageCropSize crop = MyProject.ImageCropSize.SourceCrop;
            this.Dispatcher.Invoke(DispatcherPriority.ContextIdle, new Action(delegate()
            {
                BitmapImage bmisource = image1.Source as BitmapImage;
                bmisource = null;//new BitmapImage();
                GC.Collect();
                BitmapImage bmi = MyProject.ImageData.ConvertFromBitmapToBitmapImage(((ImageBinding)sender).BitMap, crop);
                image1.Source = bmi;
                ((ImageBinding)sender).Clear();
                
            }));
        }
