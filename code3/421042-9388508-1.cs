    namespace Scratch.FileUpload {
        class MyOpenFileWebChromeClient : OpenFileWebChromeClient {
            Action<IValueCallback> cb;
            public MyOpenFileWebChromeClient(Action<IValueCallback> cb)
            {
                this.cb = cb;
            }
            public override void OpenFileChooser (IValueCallback uploadMsg)
            {
                cb (uploadMsg);
            }
        }
