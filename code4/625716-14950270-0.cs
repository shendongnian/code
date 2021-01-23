    public Bitmap GetBitmap()
    {
        int fboId;
        GL.Ext.GenFramebuffers(1, out fboId);
        CheckGLError();
        GL.Ext.BindFramebuffer(FramebufferTarget.FramebufferExt, fboId);
        CheckGLError();
        GL.Ext.FramebufferTexture2D(FramebufferTarget.FramebufferExt, FramebufferAttachment.ColorAttachment0Ext, TextureTarget.Texture2D, TextureId, 0);
        CheckGLError();
    
        Bitmap b = new Bitmap(Width, Height);
        var bits = b.LockBits(new Rectangle(0, 0, Width, Height), ImageLockMode.WriteOnly, System.Drawing.Imaging.PixelFormat.Format32bppArgb);
        GL.ReadPixels(Rect.Left, Rect.Top, Width, Height, OpenTK.Graphics.OpenGL.PixelFormat.Bgra, PixelType.UnsignedByte, bits.Scan0);
        GL.Ext.BindFramebuffer(FramebufferTarget.FramebufferExt, 0);
        GL.Ext.DeleteFramebuffers(1, ref fboId);
        b.UnlockBits(bits);
    
        return b;
    }
