    namespace Scratch.FileUpload {
        [Activity (Label = "Scratch.FileUpload", MainLauncher = true)]
        public class Activity1 : Activity
        {
            private WebView wv;
            private IValueCallback mUploadMessage;
            const int FilechooserResultcode = 1;
            protected override void OnCreate (Bundle bundle)
            {
                base.OnCreate (bundle);
                wv = new WebView (this);
                wv.SetWebViewClient(new WebViewClient());
                wv.SetWebChromeClient(new MyOpenFileWebChromeClient(uploadMsg => {
                            mUploadMessage = uploadMsg;
                            var intent = new Intent (Intent.ActionGetContent);
                            intent.AddCategory(Intent.CategoryOpenable);
                            intent.SetType("image/*");
                            StartActivityForResult(Intent.CreateChooser(intent, "File Chooser"),
                                FilechooserResultcode);
                }));
                SetHtml(null);
                SetContentView(wv);
            }
            void SetHtml(string filename)
            {
                string html = @"<html>
    <body>
    <h1>Hello, world!</h1>
    <p>Input Box:</p>
    <input type=""file"" />
    <p>URI: " + filename + @"
    </body>
    </html>";
                wv.LoadData(html, "text/html", "utf-8");
            }
            protected override void OnActivityResult (int requestCode, Result resultCode, Intent data)
            {
                base.OnActivityResult (requestCode, resultCode, data);
                if (requestCode == FilechooserResultcode) {
                    if (mUploadMessage == null)
                        return;
                    var result = data == null || resultCode != Result.Ok
                        ? null
                        : data.Data;
                    SetHtml(result.ToString());
                    mUploadMessage.OnReceiveValue(result);
                    mUploadMessage = null;
                }
            }
        }
    }
