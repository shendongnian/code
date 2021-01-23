    public class FilePreviewControl : HwndHost {
        private const int
            Child = 0x40000000,
            Visible = 0x10000000,
            HostId = 0x00000002,
            ClipChild = 0x02000000;
    
        public static readonly DependencyProperty PathProperty = DependencyProperty.Register(
            "Path", typeof (string), typeof (FilePreviewControl), new UIPropertyMetadata(Update));
    
        public static readonly DependencyProperty ExtensionProperty = DependencyProperty.Register(
            "Extension", typeof (string), typeof (FilePreviewControl), new UIPropertyMetadata(Update));
    
        public static readonly DependencyProperty SourceStreamProperty = DependencyProperty.Register(
            "SourceStream", typeof (Stream), typeof (FilePreviewControl), new UIPropertyMetadata(Update));
    
        private readonly PreviewManager manager;
        private IntPtr hwndHost;
    
        public FilePreviewControl() {
            this.manager = new PreviewManager();
        }
    
        public Stream SourceStream {
            get { return (Stream) this.GetValue(SourceStreamProperty); }
            set { this.SetValue(SourceStreamProperty, value); }
        }
    
        public string Extension {
            get { return (string) this.GetValue(ExtensionProperty); }
            set { this.SetValue(ExtensionProperty, value); }
        }
    
        public string Path {
            get { return (string) this.GetValue(PathProperty); }
            set { this.SetValue(PathProperty, value); }
        }
    
        private static void Update(DependencyObject d, DependencyPropertyChangedEventArgs e) {
            ((FilePreviewControl) d).RefreshPreview();
        }
    
        protected override HandleRef BuildWindowCore(HandleRef hwndParent) {
            this.hwndHost = IntPtr.Zero;
    
            this.hwndHost = CreateWindowEx(0, "static", "",
                Child | Visible | ClipChild,
                0, 0,
                (int) this.ActualWidth, (int) this.ActualHeight,
                hwndParent.Handle,
                (IntPtr) HostId,
                IntPtr.Zero,
                0);
    
            this.RefreshPreview();
    
            return new HandleRef(this, this.hwndHost);
        }
    
        protected override void DestroyWindowCore(HandleRef hwnd) {
            DestroyWindow(hwnd.Handle);
            this.manager.Dispose();
        }
    
        protected override void OnRenderSizeChanged(SizeChangedInfo sizeInfo) {
            base.OnRenderSizeChanged(sizeInfo);
            var rect = new Rect(new Size(this.ActualWidth, this.ActualHeight));
            this.manager.InvalidateAttachedPreview(rect);
        }
    
        protected override IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled) {
            handled = false;
            return IntPtr.Zero;
        }
    
        [DllImport("user32.dll", EntryPoint = "CreateWindowEx", CharSet = CharSet.Unicode)]
        private static extern IntPtr CreateWindowEx(
            int dwExStyle,
            string lpszClassName,
            string lpszWindowName,
            int style,
            int x,
            int y,
            int width,
            int height,
            IntPtr hwndParent,
            IntPtr hMenu,
            IntPtr hInst,
            [MarshalAs(UnmanagedType.AsAny)] object pvParam);
    
        [DllImport("user32.dll", EntryPoint = "DestroyWindow", CharSet = CharSet.Unicode)]
        private static extern bool DestroyWindow(IntPtr hwnd);
    
        private void RefreshPreview() {
            if (this.hwndHost == IntPtr.Zero)
                return;
    
            var filePath = this.Path;
            var extension = this.Extension;
    
            if (string.IsNullOrEmpty(extension) && !string.IsNullOrEmpty(filePath))
                extension = System.IO.Path.GetExtension(filePath);
    
            var shouldBeDeactivated =
                this.Visibility != Visibility.Visible ||
                (string.IsNullOrEmpty(filePath) || !File.Exists(filePath)) && this.SourceStream == null ||
                string.IsNullOrEmpty(extension);
    
            if (shouldBeDeactivated) {
                this.manager.Detach();
                return;
            }
    
            var rect = new Rect(new Size(this.RenderSize.Width, this.RenderSize.Height));
    
            try {
                this.manager.AttachPreview(
                    this.hwndHost,
                    rect,
                    extension,
                    filePath,
                    this.SourceStream);
            } catch (Exception exception) {
                Trace.TraceError(exception.ToString());
            }
        }
    
        public static bool CanPreview(string extension) {
            return PreviewManager.GetPreviewHandlerKey(extension) != null;
        }
    
        #region Nested type: InteropStream
    
        private sealed class InteropStream : IStream, IDisposable {
            private readonly Stream stream;
            private bool disposed;
    
            public InteropStream(Stream sourceStream) {
                if (sourceStream == null)
                    throw new ArgumentNullException("sourceStream");
    
                this.stream = sourceStream;
            }
    
            #region IDisposable Members
    
            public void Dispose() {
                this.Dispose(true);
                GC.SuppressFinalize(this);
            }
    
            #endregion
    
            #region IStream Members
    
            public void Clone(out IStream ppstm) {
                throw new NotSupportedException();
            }
    
            public void Commit(int grfCommitFlags) {
                throw new NotSupportedException();
            }
    
            public void CopyTo(IStream pstm, long cb, IntPtr pcbRead, IntPtr pcbWritten) {
                throw new NotSupportedException();
            }
    
            public void LockRegion(long libOffset, long cb, int dwLockType) {
                throw new NotSupportedException();
            }
    
            [SecurityCritical]
            public void Read(byte[] pv, int cb, IntPtr pcbRead) {
                var count = this.stream.Read(pv, 0, cb);
                if (pcbRead != IntPtr.Zero)
                    Marshal.WriteInt32(pcbRead, count);
            }
    
            public void Revert() {
                throw new NotSupportedException();
            }
    
            [SecurityCritical]
            public void Seek(long dlibMove, int dwOrigin, IntPtr plibNewPosition) {
                var origin = (SeekOrigin) dwOrigin;
                var pos = this.stream.Seek(dlibMove, origin);
    
                if (plibNewPosition != IntPtr.Zero)
                    Marshal.WriteInt64(plibNewPosition, pos);
            }
    
            public void SetSize(long libNewSize) {
                this.stream.SetLength(libNewSize);
            }
    
            public void Stat(out STATSTG pstatstg, int grfStatFlag) {
                pstatstg = new STATSTG {
                    type = 2,
                    cbSize = this.stream.Length,
                    grfMode = 0
                };
    
                if (this.stream.CanRead && this.stream.CanWrite)
                    pstatstg.grfMode |= 2;
    
                else if (this.stream.CanWrite && !this.stream.CanRead)
                    pstatstg.grfMode |= 1;
    
                else
                    throw new IOException();
            }
    
            public void UnlockRegion(long libOffset, long cb, int dwLockType) {
                throw new NotSupportedException();
            }
    
            [SecurityCritical]
            public void Write(byte[] pv, int cb, IntPtr pcbWritten) {
                this.stream.Write(pv, 0, cb);
    
                if (pcbWritten != IntPtr.Zero)
                    Marshal.WriteInt32(pcbWritten, cb);
            }
    
            #endregion
    
            private void Dispose(bool disposing) {
                if (this.disposed)
                    return;
    
                if (disposing && this.stream != null)
                    this.stream.Dispose();
    
                this.disposed = true;
            }
    
            ~InteropStream() {
                this.Dispose(false);
            }
        }
    
        #endregion
    
        private sealed class TempFile : IDisposable {
            private string path;
    
            public TempFile() : this(System.IO.Path.GetTempFileName()) {
            }
    
            private TempFile(string path) {
                if (string.IsNullOrEmpty(path))
                    throw new ArgumentNullException("path");
                this.path = path;
            }
    
            public string Path {
                get {
                    if (this.path == null)
                        throw new ObjectDisposedException(this.GetType().Name);
                    return this.path;
                }
            }
    
            #region IDisposable Members
    
            public void Dispose() {
                this.Dispose(true);
            }
    
            #endregion
    
            private void Dispose(bool disposing) {
                if (disposing)
                    GC.SuppressFinalize(this);
                if (this.path == null)
                    return;
    
                try {
                    File.Delete(this.path);
                } catch {
                    Trace.TraceWarning("Can't delete file " + this.path);
                } // best effort
                this.path = null;
            }
    
            ~TempFile() {
                this.Dispose(false);
            }
        }
    
        #region Nested type: PreviewManager
    
        private sealed class PreviewManager : IDisposable {
            private IPreviewHandler currentHandler;
            private bool disposed;
            private InteropStream stream;
    
            #region IDisposable Members
    
            public void Dispose() {
                this.DisposeInternal();
                GC.SuppressFinalize(this);
            }
    
            #endregion
    
            public void AttachPreview(IntPtr handler, Rect viewRect, string extension, string filePath,
                Stream sourceStream) {
                this.Unload();
    
                var classKey = GetPreviewHandlerKey(extension);
    
                if (classKey == null)
                    return;
    
                var guid = new Guid(classKey.GetValue(string.Empty).ToString());
    
                var type = Type.GetTypeFromCLSID(guid, true);
                var instance = Activator.CreateInstance(type);
    
                var fileInit = instance as IInitializeWithFile;
                var streamInit = instance as IInitializeWithStream;
    
                if (streamInit != null && sourceStream != null) {
                    this.stream = new InteropStream(sourceStream);
                    streamInit.Initialize(this.stream, 0);
                } else if (fileInit != null)
                    if (filePath != null)
                        fileInit.Initialize(filePath, 0);
    
                    else if (sourceStream != null)
                        using (var tempFile = new TempFile()) {
                            using (var fileStream = File.Create(tempFile.Path))
                                sourceStream.CopyTo(fileStream);
    
                            fileInit.Initialize(tempFile.Path, 0);
                        }
                    else
                        return;
                else
                    return;
    
                this.currentHandler = instance as IPreviewHandler;
    
                if (this.currentHandler == null) {
                    this.Unload();
                    return;
                }
    
                var rect = new ShellRect(viewRect);
    
                this.currentHandler.SetWindow(handler, ref rect);
                this.currentHandler.SetRect(ref rect);
    
                try {
                    this.currentHandler.DoPreview();
                } catch {
                    this.Unload();
                    throw;
                }
            }
    
            internal static RegistryKey GetPreviewHandlerKey(string extension) {
                var commonGuid = new Guid("8895b1c6-b41f-4c1c-a562-0d564250836f");
    
                var classKey =
                    Registry.ClassesRoot.OpenSubKey(string.Format(@"{0}\ShellEx\{1:B}", extension, commonGuid));
                return classKey;
            }
    
            public void Detach() {
                this.Unload();
            }
    
            public void InvalidateAttachedPreview(Rect viewRect) {
                if (this.currentHandler == null)
                    return;
    
                var rect = new ShellRect(viewRect);
                this.currentHandler.SetRect(ref rect);
            }
    
            private void DisposeInternal() {
                if (this.disposed)
                    return;
    
                this.Unload();
    
                this.disposed = true;
            }
    
            private void Unload() {
                if (this.currentHandler != null) {
                    this.currentHandler.Unload();
                    Marshal.FinalReleaseComObject(this.currentHandler);
                    this.currentHandler = null;
                }
    
                if (this.stream != null) {
                    this.stream.Dispose();
                    this.stream = null;
                }
            }
    
            ~PreviewManager() {
                this.DisposeInternal();
            }
    
            #region Nested type: IInitializeWithFile
    
            [ComImport]
            [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
            [Guid("b7d14566-0509-4cce-a71f-0a554233bd9b")]
            internal interface IInitializeWithFile {
                void Initialize([MarshalAs(UnmanagedType.LPWStr)] string pszFilePath, uint grfMode);
            }
    
            #endregion
    
            #region Nested type: IInitializeWithStream
    
            [ComImport]
            [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
            [Guid("b824b49d-22ac-4161-ac8a-9916e8fa3f7f")]
            internal interface IInitializeWithStream {
                void Initialize(IStream pstream, uint grfMode);
            }
    
            #endregion
    
            #region Nested type: IPreviewHandler
    
            [ComImport]
            [InterfaceType(ComInterfaceType.InterfaceIsIUnknown)]
            [Guid("8895b1c6-b41f-4c1c-a562-0d564250836f")]
            internal interface IPreviewHandler {
                void SetWindow(IntPtr hwnd, ref ShellRect rect);
                void SetRect(ref ShellRect rect);
                void DoPreview();
                void Unload();
                void SetFocus();
                void QueryFocus(out IntPtr phwnd);
    
                [PreserveSig]
                uint TranslateAccelerator(ref MSG pmsg);
            }
    
            #endregion
    
            #region Nested type: ShellRect
    
            [StructLayout(LayoutKind.Sequential)]
            internal struct ShellRect {
                public readonly int left;
                public readonly int top;
                public readonly int right;
                public readonly int bottom;
    
                public ShellRect(Rect rect) {
                    this.top = (int) rect.Top;
                    this.bottom = (int) rect.Bottom;
                    this.left = (int) rect.Left;
                    this.right = (int) rect.Right;
                }
            }
    
            #endregion
        }
    
        #endregion
    }
