    public class Gif
    {
        public static List<Frame> LoadAnimatedGif(string path)
        {
            //If path is not found, we should throw an IO exception
            if (!File.Exists(path))
                throw new IOException("File does not exist");
    
            //Load the image
            var img = Image.FromFile(path);
    
            //Count the frames
            var frameCount = img.GetFrameCount(FrameDimension.Time);
    
            //If the image is not an animated gif, we should throw an
            //argument exception
            if (frameCount <= 1)
                throw new ArgumentException("Image is not animated");
    
            //List that will hold all the frames
            var frames = new List<Frame>();
    
            //Get the times stored in the gif
            //PropertyTagFrameDelay ((PROPID) 0x5100) comes from gdiplusimaging.h
            //More info on http://msdn.microsoft.com/en-us/library/windows/desktop/ms534416(v=vs.85).aspx
            var times = img.GetPropertyItem(0x5100).Value;
    
            //Convert the 4bit duration chunk into an int
    
            for (int i = 0; i < frameCount; i++)
            {
                //convert 4 bit value to integer
                var duration = BitConverter.ToInt32(times, 4*i);
    
                //Add a new frame to our list of frames
                frames.Add(
                    new Frame()
                    {
                        Image = new Bitmap(img),
                        Duration = duration
                    });
    
                //Set the write frame before we save it
                img.SelectActiveFrame(FrameDimension.Time, i);
    
    
            }
    
            //Dispose the image when we're done
            img.Dispose();
    
            return frames;
        }
    }
