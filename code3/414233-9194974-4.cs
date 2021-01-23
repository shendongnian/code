        public class ImageSettings : IImageSettings 
        {
            public int posX { get; set; }
            public int posY { get; set; }
            public StringFormat format { get; set; }
            public string value { get; set; }
            public Font font { get; set; }
            public bool caption { get; set; }
            public Font captionFont { get; set; }
        }
        public interface IImageSettings 
        {
            int posX { get; set; }
            int posY { get; set; }
            StringFormat format { get; set; }
            string value { get; set; }
            Font font { get; set; }
            bool caption { get; set; }
            Font captionFont { get; set; }
        }
        public class ImageCreator : IImageCreator
        {
