    public static class WriteableBitmapRenderExtensions
    {
        public static async Task Render(this WriteableBitmap wb, FrameworkElement fe)
        {
            var ms = RenderToStream(fe);
            var msrandom = new MemoryRandomAccessStream(ms);
            await wb.SetSourceAsync(msrandom);
        }
        public static MemoryStream RenderToStream(FrameworkElement fe)
        {
            return new CompositionEngine().RenderToPngStream(fe);
        }
    }
    public class CompositionEngine
    {
        private readonly ImagingFactory _wicFactory;
        private readonly SharpDX.Direct2D1.Factory _d2DFactory;
        private readonly SharpDX.DirectWrite.Factory _dWriteFactory;
        public CompositionEngine()
        {
            _wicFactory = new ImagingFactory();
            _d2DFactory = new SharpDX.Direct2D1.Factory();
            this._dWriteFactory = new SharpDX.DirectWrite.Factory();
        }
        public ImagingFactory WicFactory
        {
            get
            {
                return this._wicFactory;
            }
        }
        public SharpDX.Direct2D1.Factory D2DFactory
        {
            get
            {
                return this._d2DFactory;
            }
        }
        public SharpDX.DirectWrite.Factory DWriteFactory
        {
            get
            {
                return this._dWriteFactory;
            }
        }
        public MemoryStream RenderToPngStream(FrameworkElement fe)
        {
            var width = (int)Math.Ceiling(fe.ActualWidth);
            var height = (int)Math.Ceiling(fe.ActualHeight);
            // pixel format with transparency/alpha channel and RGB values premultiplied by alpha
            var pixelFormat = WicPixelFormat.Format32bppPRGBA;
            // pixel format without transparency, but one that works with Cleartype antialiasing
            //var pixelFormat = WicPixelFormat.Format32bppBGR;
            var wicBitmap = new Bitmap(
                this.WicFactory,
                width,
                height,
                pixelFormat,
                BitmapCreateCacheOption.CacheOnLoad);
            var renderTargetProperties = new RenderTargetProperties(
                RenderTargetType.Default,
                new D2DPixelFormat(Format.R8G8B8A8_UNorm, AlphaMode.Premultiplied),
                //new D2DPixelFormat(Format.Unknown, AlphaMode.Unknown), // use this for non-alpha, cleartype antialiased text
                0,
                0,
                RenderTargetUsage.None,
                FeatureLevel.Level_DEFAULT);
            var renderTarget = new WicRenderTarget(
                this.D2DFactory,
                wicBitmap,
                renderTargetProperties)
            {
                //TextAntialiasMode = TextAntialiasMode.Cleartype // this only works with the pixel format with no alpha channel
                TextAntialiasMode = TextAntialiasMode.Grayscale // this is the best we can do for bitmaps with alpha channels
            };
            Compose(renderTarget, fe);
            // TODO: There is no need to encode the bitmap to PNG - we could just copy the texture pixel buffer to a WriteableBitmap pixel buffer.
            var ms = new MemoryStream();
            var stream = new WICStream(
                this.WicFactory,
                ms);
            var encoder = new PngBitmapEncoder(WicFactory);
            encoder.Initialize(stream);
            var frameEncoder = new BitmapFrameEncode(encoder);
            frameEncoder.Initialize();
            frameEncoder.SetSize(width, height);
            var format = WicPixelFormat.Format32bppBGRA;
            //var format = WicPixelFormat.FormatDontCare;
            frameEncoder.SetPixelFormat(ref format);
            frameEncoder.WriteSource(wicBitmap);
            frameEncoder.Commit();
            encoder.Commit();
            frameEncoder.Dispose();
            encoder.Dispose();
            stream.Dispose();
            ms.Position = 0;
            return ms;
        }
        public void Compose(RenderTarget renderTarget, FrameworkElement fe)
        {
            renderTarget.BeginDraw();
            Do your rendering here
            renderTarget.Clear(new Color(0, 0, 0, 0));
            Render(renderTarget, fe, fe);
            renderTarget.EndDraw();
        }
    }
