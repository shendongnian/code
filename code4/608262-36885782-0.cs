    public static Image<TColor, TDepth> GetAxisAlignedImagePart<TColor, TDepth>(
        this Image<TColor, TDepth> input,
        Quadrilateral rectSrc,
        Quadrilateral rectDst,
        Size targetImageSize)
        where TColor : struct, IColor
        where TDepth : new()
    {
        var src = new[] { rectSrc.P0, rectSrc.P1, rectSrc.P2, rectSrc.P3 };
        var dst = new[] { rectDst.P0, rectDst.P1, rectDst.P2, rectDst.P3 };
        using (var matrix = CvInvoke.GetPerspectiveTransform(src, dst))
        {
            using (var cutImagePortion = new Mat())
            {
                CvInvoke.WarpPerspective(input, cutImagePortion, matrix, targetImageSize, Inter.Cubic);
                return cutImagePortion.ToImage<TColor, TDepth>();
            }
        }
    }
