    using System;
    using Windows.UI.Xaml.Media.Imaging;
    namespace ImageUserControl
    {
        public class ViewModelLocator
        {
            static ViewModelLocator()
            {}
            public PictureViewModel Main
            {
                get
                {
                    return new PictureViewModel
                    {                    
                        PictureUri = new BitmapImage(new Uri("ms-resource:/Files/Assets/eels.jpg"))
                    };
                }
            }
        }
    }
