		public void SaveJpg(string path, Bitmap img, long quality) {
			// Encoder parameter for image quality
			EncoderParameter qualityParam = new EncoderParameter(Encoder.Quality, quality);
			// Jpeg image codec
			ImageCodecInfo jpegCodec = this.getEncoderInfo("image/jpeg");
			EncoderParameters encoderParams = new EncoderParameters(1);
			encoderParams.Param[0] = qualityParam;
			img.Save(path, jpegCodec, encoderParams);
		}
