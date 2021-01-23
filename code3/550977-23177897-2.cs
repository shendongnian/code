					var lookupR = new byte[256];
					var lookupG = new byte[256];
					var lookupB = new byte[256];
					var rVal = hdtv ? 0.114 : 0.0722;
					var gVal = hdtv ? 0.587 : 0.7152;
					var bVal = hdtv ? 0.299 : 0.2126;
					for (var originalValue = 0; originalValue < 256; originalValue++)
					{
						var r = (byte)(originalValue * rVal);
						var g = (byte)(originalValue * gVal);
						var b = (byte)(originalValue * bVal);
						// Just in case...
						if (r > 255) r = 255;
						if (g > 255) g = 255;
						if (b > 255) b = 255;
						lookupR[originalValue] = r;
						lookupG[originalValue] = g;
						lookupB[originalValue] = b;
					}
					unsafe
					{
						var pointer = (byte*)(void*)bitmap.LockBits(new Rectangle(0, 0, bitmap.Width, bitmap.Height), ImageLockMode.ReadWrite, bitmap.PixelFormat);
						var bytesPerPixel = getBytesPerPixel(bitmap);
						var heightWidth = bitmap.Width * bitmap.Height;
						for (var y = 0; y < heightWidth; ++y)
						{
							var value = (byte) (lookupR[pointer[0]] + lookupG[pointer[1]] + lookupB[pointer[2]]);
							pointer[0] = value;
							pointer[1] = value;
							pointer[2] = value;
							pointer += bytesPerPixel;
						}
						bitmap.UnlockBits();
					}
					break;
