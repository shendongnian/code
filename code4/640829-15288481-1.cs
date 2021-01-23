    //top left
    var bandImg1 = result.Clone(new Rectangle(0, 0, result.Width / 2, result.Height / 2), result.PixelFormat);
    //top right
    var bandImg2 = result.Clone(new Rectangle(result.Width / 2, 0, result.Width / 2, result.Height / 2), result.PixelFormat);
    //bottom left
    var bandImg3 = result.Clone(new Rectangle(0, result.Height / 2, result.Width / 2, result.Height / 2), result.PixelFormat);
    //bottom right
    var bandImg4 = result.Clone(new Rectangle(result.Width / 2, result.Height / 2, result.Width / 2, result.Height / 2), result.PixelFormat);
    Bitmap[] corners = new Bitmap[] { bandImg1, bandImg2, bandImg3, bandImg4 };
    string QRinfo = "";
    for (int i = 0; i < corners.Length; ++i)
    {
    	string tmpQRinfo = Process(corners[i]);//this  should pass in the bandImg depending on the above search finding which corner has a qr image
                    
       	//check if string is valid, you'll need to figure out how to do this
    	if (valid)
    	{
            QRinfo = tmpQRinfo;
    		switch(i)
    		{
    			case 0: //already in upper left, do nothing
    				break;
    			case 1: //upper right corner, so rotate the document -90 which is the same as 270
    				fullImg.RotateFlip(RotateFlipType.Rotate270FlipNone);
    				break;
    			case 2: //lower left corner, so rotate 90
    				fullImg.RotateFlip(RotateFlipType.Rotate90FlipNone);
    				break;
    			case 3: //lower right corner, so rotate 180
    				fullImg.RotateFlip(RotateFlipType.Rotate180FlipNone);
    				break;
    		}
            break; //the QR was found, no need to continue searching
    	}
    }
    MessageBox.Show(QRinfo);
