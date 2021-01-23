        public Bitmap GetImageResourceByName(string name)
        {
            Bitmap MethodResult = null;
            try
            {
                MethodResult = (Bitmap)XXXAPPNAMEXXX.Properties.Resources.ResourceManager.GetObject(name, XXXAPPNAMEXXX.Properties.Resources.resourceCulture);
            }
            catch //(Exception ex)
            {
                //ex.HandleException();
            }
            return MethodResult;
        }
