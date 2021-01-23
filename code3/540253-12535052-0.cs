    using System.Linq;
    using System.Windows.Controls.Primitives;
    // ...
    private void DoStuff()
    {
        var myImage = this.MyRootLayoutPanel.GetVisualDescendants().OfType<Image>()
            .Where(img => img.Name == "MyImageName").FirstOrDefault();
    }
