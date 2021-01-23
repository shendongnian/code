    var decoder = new TiffBitmapDecoder(new Uri(fileName), BitmapCreateOptions.None, BitmapCacheOption.Default);
    var metadata = (BitmapMetadata)decoder.Frames[0].Metadata;
    string xml = (string)metadata.GetQuery("/ifd/{ushort=270}");
    var doc = XDocument.Parse(xml);
    var ns = doc.Root.GetDefaultNamespace();
    doc.Dump();
    var plane = doc.Root.Element(ns + "Image")
                        .Element(ns + "Pixels")
                        .Element(ns + "Plane");
    double deltaT = (double)plane.Attribute("DeltaT");
