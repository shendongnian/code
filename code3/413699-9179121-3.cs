    public class ExtendedImageController
    {
        // add methods and properties as necessary
    }
    // client code
    var img = new Image(); // ...
    img.Tag = new ExtendedImageController(img); // with reference to image
    // in some event handler:
    var ctrl = (ExtendedImageController)img.Tag;
    ctrl.DoCleanupThings(); 
    // ...
