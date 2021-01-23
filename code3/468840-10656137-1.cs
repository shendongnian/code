    using System.Windows.Interop;
    ...
        protected override void OnSourceInitialized(EventArgs e)
        {
            HwndSource hwndSource = PresentationSource.FromVisual(this) as HwndSource;
            HwndTarget hwndTarget = hwndSource.CompositionTarget;
            hwndTarget.RenderMode = RenderMode.SoftwareOnly;
            media.Play();
            base.OnSourceInitialized(e);
        }
