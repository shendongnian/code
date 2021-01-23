    //------------------------------------------------------------------------------
    static void CopyIntoBitmap_Pointer (array<unsigned char>^ i_aui8ImageData,
                                        BitmapData^ i_ptrBitmap,
                                        int i_iBytesPerPixel)
    {
      char* scan0 = (char*)(i_ptrBitmap->Scan0.ToPointer ());
      int ixCnt = 0;
      for (int ixRow = 0; ixRow < i_ptrBitmap->Height; ixRow++)
      {
        for (int ixCol = 0; ixCol < i_ptrBitmap->Width; ixCol++)
        {
          char* pPixel = scan0 + ixRow * i_ptrBitmap->Stride + ixCol * 3;
          pPixel[0] = i_aui8ImageData[ixCnt++];
          pPixel[1] = i_aui8ImageData[ixCnt++];
          pPixel[2] = i_aui8ImageData[ixCnt++];
        }
      }
    }
    //------------------------------------------------------------------------------
    static void CopyIntoBitmap_MarshallLarge (array<unsigned char>^ i_aui8ImageData,
                                              BitmapData^ i_ptrBitmap)
    {
      IntPtr ptrScan0 = i_ptrBitmap->Scan0;
      Marshal::Copy (i_aui8ImageData, 0, ptrScan0, i_aui8ImageData->Length);
    }
    //------------------------------------------------------------------------------
    static void CopyIntoBitmap_MarshalSmall (array<unsigned char>^ i_aui8ImageData,
                                             BitmapData^ i_ptrBitmap,
                                             int i_iBytesPerPixel)
    {
      int ixCnt = 0;
      for (int ixRow = 0; ixRow < i_ptrBitmap->Height; ixRow++)
      {
        for (int ixCol = 0; ixCol < i_ptrBitmap->Width; ixCol++)
        {
          IntPtr ptrScan0 = IntPtr::Add (i_ptrBitmap->Scan0, i_iBytesPerPixel);
          Marshal::Copy (i_aui8ImageData, ixCnt, ptrScan0, i_iBytesPerPixel);
          ixCnt += i_iBytesPerPixel;
        }
      }
    }
    //------------------------------------------------------------------------------
    void main ()
    {
      int iWidth = 10000;
      int iHeight = 10000;
      int iBytesPerPixel = 3;
      Bitmap^ oBitmap = gcnew Bitmap (iWidth, iHeight, PixelFormat::Format24bppRgb);
      BitmapData^ oBitmapData = oBitmap->LockBits (Rectangle (0, 0, iWidth, iHeight), ImageLockMode::WriteOnly, oBitmap->PixelFormat);
      array<unsigned char>^ aui8ImageData = gcnew array<unsigned char> (iWidth * iHeight * iBytesPerPixel);
      int ixCnt = 0;
      for (int ixRow = 0; ixRow < iHeight; ixRow++)
      {
        for (int ixCol = 0; ixCol < iWidth; ixCol++)
        {
          aui8ImageData[ixCnt++] = ixRow * 250 / iHeight;
          aui8ImageData[ixCnt++] = ixCol * 250 / iWidth;
          aui8ImageData[ixCnt++] = ixCol;
        }
      }
      //========== Pointer ==========
      // ~ 8.97 sec for 10k * 10k * 3 * 10 exec, ~ 334 MB/s
      int iExec = 10;
      DateTime dtStart = DateTime::Now;
      for (int ixExec = 0; ixExec < iExec; ixExec++)
      {
        CopyIntoBitmap_Pointer (aui8ImageData, oBitmapData, iBytesPerPixel);
      }
      TimeSpan tsDuration = DateTime::Now - dtStart;
      Console::WriteLine (tsDuration + "  " + ((double)aui8ImageData->Length * iExec / tsDuration.TotalSeconds / 1e6));
      //========== Marshal.Copy, 1 large block ==========
      // 3.94 sec for 10k * 10k * 3 * 100 exec, ~ 7617 MB/s
      iExec = 100;
      dtStart = DateTime::Now;
      for (int ixExec = 0; ixExec < iExec; ixExec++)
      {
        CopyIntoBitmap_MarshallLarge (aui8ImageData, oBitmapData);
      }
      tsDuration = DateTime::Now - dtStart;
      Console::WriteLine (tsDuration + "  " + ((double)aui8ImageData->Length * iExec / tsDuration.TotalSeconds / 1e6));
      //========== Marshal.Copy, many small 3-byte blocks ==========
      // 41.7 sec for 10k * 10k * 3 * 10 exec, ~ 72 MB/s
      iExec = 10;
      dtStart = DateTime::Now;
      for (int ixExec = 0; ixExec < iExec; ixExec++)
      {
        CopyIntoBitmap_MarshalSmall (aui8ImageData, oBitmapData, iBytesPerPixel);
      }
      tsDuration = DateTime::Now - dtStart;
      Console::WriteLine (tsDuration + "  " + ((double)aui8ImageData->Length * iExec / tsDuration.TotalSeconds / 1e6));
      //========== Buffer.BlockCopy, 1 large block ==========
      // 4.02 sec for 10k * 10k * 3 * 100 exec, ~ 7467 MB/s
      iExec = 100;
      array<unsigned char>^ aui8Buffer = gcnew array<unsigned char> (aui8ImageData->Length);
      dtStart = DateTime::Now;
      for (int ixExec = 0; ixExec < iExec; ixExec++)
      {
        Buffer::BlockCopy (aui8ImageData, 0, aui8Buffer, 0, aui8ImageData->Length);
      }
      tsDuration = DateTime::Now - dtStart;
      Console::WriteLine (tsDuration + "  " + ((double)aui8ImageData->Length * iExec / tsDuration.TotalSeconds / 1e6));
      //========== Buffer.BlockCopy, many small 3-byte blocks ==========
      // 28.0 sec for 10k * 10k * 3 * 10 exec, ~ 107 MB/s
      iExec = 10;
      dtStart = DateTime::Now;
      for (int ixExec = 0; ixExec < iExec; ixExec++)
      {
        int ixCnt = 0;
        for (int ixRow = 0; ixRow < iHeight; ixRow++)
        {
          for (int ixCol = 0; ixCol < iWidth; ixCol++)
          {
            Buffer::BlockCopy (aui8ImageData, ixCnt, aui8Buffer, ixCnt, iBytesPerPixel);
            ixCnt += iBytesPerPixel;
          }
        }
      }
      tsDuration = DateTime::Now - dtStart;
      Console::WriteLine (tsDuration + "  " + ((double)aui8ImageData->Length * iExec / tsDuration.TotalSeconds / 1e6));
      oBitmap->UnlockBits (oBitmapData);
      oBitmap->Save ("d:\\temp\\bitmap.bmp", ImageFormat::Bmp);
    }
