        private WriteableBitmap bSave;
        private WriteableBitmap bBase;
        private void test()
        {
            bSave = BitmapFactory.New(200, 200); //your destination
            bBase = BitmapFactory.New(200, 200); //your source
            //here paint something on either bitmap.
            Rect rec = new Rect(0, 0, 199, 199);
            using (bSave.GetBitmapContext())
            {
                using (bBase.GetBitmapContext())
                {
                    bSave.Blit(rec, bBase, rec, WriteableBitmapExtensions.BlendMode.Additive);
                }
            }
        }
