    class MyClass
    {
      [DllImport("kernel32.dll", EntryPoint = "CopyMemory", SetLastError = false)]
      public static extern void CopyMemory(IntPtr dest, IntPtr src, uint count);
      Bitmap _frame = null;
      BitmapData _dest = null;
      void Reinit( int width, int height, PixelFormat format )
      {
        if ( _frame != null )
        {
          _frame.Unlock(_dest);
          _frame.Dispose();
        }
        _frame = new Bitmap( width, height, format );
        _dest = _frame.LockBits( new Rectangle( 0, 0, _frame.Width, _frame.Height ), ImageLockMode.ReadWrite, _frame.PixelFormat );
      }
      void CloneBitmapData( BitmapData src )
      {
        if ( _dest == null || _dest.Width != src.Width || _dest.Height != src.Height )
          Reinit( src.Width, src.Height, src.PixelFormat );
        
        CopyMemory( _dest.Scan0, src.Scan0, (uint)(src.Stride * src.Height) );
      }
