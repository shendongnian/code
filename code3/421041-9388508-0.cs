    using System;
    using Android.App;
    using Android.Content;
    using Android.Runtime;
    using Android.OS;
    using Android.Webkit;
    namespace Scratch.FileUpload
    {
        [Register ("android/webkit/WebChromeClient", DoNotGenerateAcw=true)]
        class OpenFileWebChromeClient : WebChromeClient {
            static IntPtr id_openFileChooser;
            [Register ("openFileChooser", "(Landroid/webkit/ValueCallback;)V", "GetOpenFileChooserHandler")]
            public virtual void OpenFileChooser (IValueCallback uploadMsg)
            {
                if (id_openFileChooser == IntPtr.Zero)
                    id_openFileChooser = JNIEnv.GetMethodID (ThresholdClass, "openFileChooser", "(Landroid/webkit/ValueCallback;)V");
                if (GetType () == ThresholdType)
                    JNIEnv.CallVoidMethod  (Handle, id_openFileChooser, new JValue (JNIEnv.ToJniHandle (uploadMsg)));
                else
                    JNIEnv.CallNonvirtualVoidMethod  (Handle, ThresholdClass, id_openFileChooser, new JValue (JNIEnv.ToJniHandle (uploadMsg)));
            }
    #pragma warning disable 0169
            static Delegate cb_openFileChooser;
            static Delegate GetOpenFileChooserHandler ()
            {
                if (cb_openFileChooser == null)
                    cb_openFileChooser = JNINativeWrapper.CreateDelegate ((Action<IntPtr, IntPtr, IntPtr>) n_OpenFileChooser);
                return cb_openFileChooser;
            }
            static void n_OpenFileChooser (IntPtr jnienv, IntPtr native__this, IntPtr native_uploadMsg)
            {
                OpenFileWebChromeClient __this = Java.Lang.Object.GetObject<OpenFileWebChromeClient> (native__this, JniHandleOwnership.DoNotTransfer);
                var uploadMsg = Java.Lang.Object.GetObject<IValueCallback> (native_uploadMsg, JniHandleOwnership.DoNotTransfer);
                __this.OpenFileChooser (uploadMsg);
            }
    #pragma warning restore 0169
        }
    }
