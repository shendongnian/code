    private static bool IsSearchedImageFound(this Bitmap template, Bitmap image)
        {
            const Int32 divisor = 4;
            const Int32 epsilon = 10;
            ExhaustiveTemplateMatching etm = new ExhaustiveTemplateMatching(0.90f);
            TemplateMatch[] tm = etm.ProcessImage(
                new ResizeNearestNeighbor(template.Width / divisor, template.Height / divisor).Apply(template),
                new ResizeNearestNeighbor(image.Width / divisor, image.Height / divisor).Apply(image)
                );
            if (tm.Length == 1)
            {
                Rectangle tempRect = tm[0].Rectangle;
                if (Math.Abs(image.Width / divisor - tempRect.Width) < epsilon
                    &&
                    Math.Abs(image.Height / divisor - tempRect.Height) < epsilon)
                {
                    return true;
                }
            }
            return false;
        }
