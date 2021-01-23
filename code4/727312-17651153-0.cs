        public FileContentResult GetImg(int id)
        {
            byte[] byteArray = new Model().GetImgByID(id);
            if (byteArray != null)
            {
                return new FileContentResult(byteArray, "image/png");
            }
            else
            {
                //something failed, image not found!
                return null;
            }
        }
