    public partial class MultiImage : UserControl
        {
            public BitmapImage MainIcon {             
                set { this.mainIcon.Source = value;}
            }
            public BitmapImage StatusIcon{             
                set { this.statusIcon.Source = value;}
            }
        public MultiImage()
        {
            this.mainIcon = new Image();
            this.mainIcon.Source = new BitmapImage(new Uri("Images/laptop.png", UriKind.Relative));
            this.statusIcon = new Image();
            this.statusIcon.Source = new BitmapImage(new Uri("Images/warning.png", UriKind.Relative));
        }
    }
