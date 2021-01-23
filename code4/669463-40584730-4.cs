    internal sealed class EtiquetaTestCommand1 : Label, IDisposable
	{
		private Bitmap _bmp;
		internal EtiquetaTestCommand1(Size size, int gapLength, Point referencePoint, int numberCopies, string barcod) : base(size, gapLength, referencePoint, numberCopies, barcod)
		{
			int x = 5;
			int y = 5;
			((IComplexCommand)this).AddCommand(BarCodeCommand.Code128ModeABarCodeCommand(x, y, barcod));
		}
		~EtiquetaTestCommand1()
		{
			this.Dispose(false);
		}
		private void Dispose(bool disposing)
		{
			if (disposing)
			{
			}
		}
		void IDisposable.Dispose()
		{
			this.Dispose(true);
		}
	}
