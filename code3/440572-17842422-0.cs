    for (int i = 0; i < 50; i++)
    {
         ppaForm.SetBitmap(bitmap, (byte)(255 - i * 5));
         ppaForm.Show();
         ppaForm.TopMost = false;
         ppaForm.TopMost = true;
         Thread.Sleep(6);
    }
