    using (marker.GetBitmapContext(ReadWriteMode.ReadOnly))
    {
        using(bitmap.GetContext())
        {    
            foreach (var point in TransformedPoints)
            {
                bitmap.Blit(new Rect((int)point.X, (int)point.Y, 5, 5), marker, sourceRect);
            }
        }
    }
