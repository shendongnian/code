    using System.Drawing;
    using System.Windows.Media;
    ...
    Icon someIcon = Properties.Resources.WindowIcon;
    Bitmap someBitmap = someIcon.ToBitmap();
    this.Icon = (ImageSource)new ImageSourceConverter().ConvertFrom(someBitmap);
