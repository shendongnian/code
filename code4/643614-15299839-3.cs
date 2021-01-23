    Bitmap[] corners = new Bitmap[] { bandImg1, bandImg2, bandImg3, bandImg4 };
    string QRinfo = "";
    for (int i = 0; i < corners.Length; ++i)
    {
    	string tempQRinfo = Process(corners[i]);
    	if (tempQRinfo != null) //if the string is NOT null, then we found the QR. If it is null, then the for loop will continue searching if it has more corners to look at
    	{
    		QRinfo = tempQRinfo;
    		switch (i)
    		{
    			case 0: break; //upper left
    			case 1: fullImg.RotateFlip(RotateFlipType.Rotate270FlipNone); break;
    			case 2: fullImg.RotateFlip(RotateFlipType.Rotate90FlipNone); break;
    			case 3: fullImg.RotateFlip(RotateFlipType.Rotate180FlipNone); break;
    		}
    		break;
    	}
    }
