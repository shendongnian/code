    private System.Drawing.Image ObjToImg(byte[] obj)
        {
            if (obj == null)
                return null;
            else
            {
                BinaryFormatter bf = new BinaryFormatter();
                using(MemoryStream ms = new MemoryStream(obj))
                {
                  return (System.Drawing.Image)bf.Deserialize(ms);
                }
            }
        }
    private byte[] ImgToObj(System.Drawing.Image obj)
        {
            if (obj == null)
                return null;
            else
            {
                BinaryFormatter bf = new BinaryFormatter();
                using(MemoryStream ms = new MemoryStream())
                {
                  bf.Serialize(ms, obj);
                  return ms.ToArray();
                }
            }
        }
