    using Android.Runtime;
    namespace Org.Taptwo.Android.Widget {
     
      partial class ViewFlow {
        protected override Java.Lang.Object RawAdapter {
          get {return Adapter.JavaCast<Java.Lang.Object>();}
          set {Adapter = value.JavaCast<global::Android.Widget.IListAdapter>();}
        }
      }
    }
