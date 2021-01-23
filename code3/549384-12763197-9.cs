    public class ImageViewModel : ViewModelBase
    {
        public ImageViewModel(string name, string image)
        {
            Name = name;
            Image = image;
        }
        
        // Name or Path? Please make the choice by yourself! =)
        public string Name { get; private set; }
        public BitmapImage Image { get; private set; }
    }
