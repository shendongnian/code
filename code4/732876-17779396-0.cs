    using System.Collections;
    string image_name = "Desert";
    foreach (DictionaryEntry kvp in Properties.Resources.ResourceManager.GetResourceSet(CultureInfo.CurrentCulture, true, true)) {
        if ((string)kvp.Key == image_name) {
            var bmp = kvp.Value as Bitmap;
            if (bmp != null) {
                // bmp is your image
            }
        }
    }
