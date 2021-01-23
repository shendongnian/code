		using System.Runtime.InteropServices;
		using System.Linq;
		using System.Drawing.Imaging;
		using System.Drawing;
		using System;
		public static partial class ImageExtensions {
			public static ColorPalette ToGrayScale(this ColorPalette palette) {
				var entries=palette.Entries;
				for(var i=entries.Length; i-->0; entries[i]=entries[i].ToGrayScale())
					;
				return palette;
			}
			public static Color ToGrayScale(this Color color, double[] luminance=null) {
				var list=(luminance??new[] { 0.2989, 0.5870, 0.1140 }).ToList();
				var channel=new[] { color.R, color.G, color.B };
				var c=(byte)Math.Round(list.Sum(x => x*channel[list.IndexOf(x)]));
				return Color.FromArgb(c, c, c);
			}
			public static Bitmap To8bppIndexed(this Bitmap original) {
				var rect=new Rectangle(Point.Empty, original.Size);
				var pixelFormat=PixelFormat.Format8bppIndexed;
				var destination=new Bitmap(rect.Width, rect.Height, pixelFormat);
				using(var source=original.Clone(rect, PixelFormat.Format32bppArgb)) {
					var destinationData=destination.LockBits(rect, ImageLockMode.WriteOnly, pixelFormat);
					var sourceData=source.LockBits(rect, ImageLockMode.ReadOnly, source.PixelFormat);
					var destinationSize=destinationData.Stride*destinationData.Height;
					var destinationBuffer=new byte[destinationSize];
					var sourceSize=sourceData.Stride*sourceData.Height;
					var sourceBuffer=new byte[sourceSize];
					Marshal.Copy(sourceData.Scan0, sourceBuffer, 0, sourceSize);
					source.UnlockBits(sourceData);
					destination.Palette=destination.Palette.ToGrayScale();
					var list=destination.Palette.Entries.ToList();
					for(var y=destination.Height; y-->0; ) {
						for(var x=destination.Width; x-->0; ) {
							var pixelIndex=y*destination.Width+x;
							var sourceIndex=4*pixelIndex;
							var color=
								Color.FromArgb(
									sourceBuffer[0+sourceIndex],
									sourceBuffer[1+sourceIndex],
									sourceBuffer[2+sourceIndex],
									sourceBuffer[3+sourceIndex]
									).ToGrayScale();
							destinationBuffer[pixelIndex]=(byte)list.IndexOf(color);
						}
					}
					Marshal.Copy(destinationBuffer, 0, destinationData.Scan0, destinationSize);
					destination.UnlockBits(destinationData);
				}
				return destination;
			}
		}
