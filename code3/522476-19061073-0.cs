    public static Image RotateImage(Image image)
            {
                image.RotateFlip(RotateFlipType.Rotate180FlipNone);
                return image;
            }
