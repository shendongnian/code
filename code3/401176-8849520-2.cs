	using (MemoryStream memoryStream = new MemoryStream())
		{
			EncoderParameter qualityParam = new EncoderParameter(Encoder.Quality, 80); // edit image quality here
			ImageCodecInfo jpegCodec = this.getEncoderInfo("image/jpeg");
			EncoderParameters encoderParams = new EncoderParameters(1);
			encoderParams.Param[0] = qualityParam;
			ImageToWatermark.Save(memoryStream, encoderParams);
			imageBytes = memoryStream.ToArray();
		}
