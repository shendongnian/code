        public class ImageThing : IImageProvider {
            //Store a reference to the main document so that we can access the page size and margins
            private Document MainDoc;
            //Constructor
            public  ImageThing(Document doc) {
                this.MainDoc = doc;
            }
            Image IImageProvider.GetImage(string src, IDictionary<string, string> attrs, ChainedProperties chain, IDocListener doc) {
                //Prepend the src tag with our path. NOTE, when using HTMLWorker.IMG_PROVIDER, HTMLWorker.IMG_BASEURL gets ignored unless you choose to implement it on your own
                src = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\" + src;
                //Get the image. NOTE, this will attempt to download/copy the image, you'd really want to sanity check here
                Image img = Image.GetInstance(src);
                //Make sure we got something
                if (img == null) return null;
                //Determine the usable area of the canvas. NOTE, this doesn't take into account the current "cursor" position so this might create a new blank page just for the image
                float usableW = this.MainDoc.PageSize.Width - (this.MainDoc.LeftMargin + this.MainDoc.RightMargin);
                float usableH = this.MainDoc.PageSize.Height - (this.MainDoc.TopMargin + this.MainDoc.BottomMargin);
                //If the downloaded image is bigger than either width and/or height then shrink it
                if (img.Width > usableW || img.Height > usableH) {
                    img.ScaleToFit(usableW, usableH);
                }
                //return our image
                return img;
            }
        }
