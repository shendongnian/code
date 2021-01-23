            ffmp.Start("test.avi", 25);
            for (int i = 0; i < 500; i++)
            {
                using(bitmap = (Bitmap)sc.CaptureScreen())
                {
                    ffmp.PushFrame(bitmap);
                    System.Threading.Thread.Sleep(35);
                }
            }
            ffmp.Close();
