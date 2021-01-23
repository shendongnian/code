    public static void TexImage2D(int target, int level, int internalformat, Int32 width, Int32 height, int border, int format, int type, object pixels) {
        GCHandle pp_pixels = GCHandle.Alloc(pixels, GCHandleType.Pinned);
        try {
            if      (Delegates.pglTexImage2D != null)
                Delegates.pglTexImage2D(target, level, internalformat, width, height, border, format, type, pp_pixels.AddrOfPinnedObject());
            else
                throw new InvalidOperationException("binding point TexImage2D cannot be found");
         } finally {
             pp_pixels.Free();
         }         
    }
