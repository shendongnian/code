    sealed class ImageWrapper : ControlWrapper
    {
        public ImageWrapper(XElement element) { } : base(element)
        
        protected override Control _MakeControl()
        {
            var image = new Image();
            var pos = element.Element("Position");
            var x = int.Parse(pos.Element("X").Value);
            var y = int.Parse(pos.Element("y").Value);
            image.Position = new Point(x, y);
            
            //continue setting other properties...
            
            return image;
        }
    }
