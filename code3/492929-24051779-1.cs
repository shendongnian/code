    [NotMapped]
		public System.Drawing.Image MyPhoto
		{
			get
			{
				 
				if (Photo == null)
				{
					return BlankImage;   
					 
				}
				else
				{
					if (Photo.Length == 0)
					{
						return BlankImage;  
					 
					}
					else
					{
						return byteArrayToImage(Photo);
					}
				}
			}
			set
			{
				if (value == null)
				{
					Photo = null;
				}
				else
				{
					if (value.Height == BlankImage.Height)  // cheating
					{
						Photo = null;
					}
					else
					{
						Photo = imageToByteArray(value);
					}
				}
			}
		}
		[NotMapped]
		public Image BlankImage {
			get
			{
			 
				return new Bitmap(1,1);
			}
		}
     
		public static byte[] imageToByteArray(Image imageIn)
		{
			 
				MemoryStream ms = new MemoryStream();
				imageIn.Save(ms, ImageFormat.Gif);
				return ms.ToArray();
			 
		}
		 
		public static Image byteArrayToImage(byte[] byteArrayIn)
		{
			 
				MemoryStream ms = new MemoryStream(byteArrayIn);
				Image returnImage = Image.FromStream(ms);
				return returnImage;
			 
		}
