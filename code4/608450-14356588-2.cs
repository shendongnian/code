    using System;
	using System.Windows;
	using System.Windows.Data;
	using System.Windows.Controls;
	public class ImageAsyncHelper : DependencyObject {
		public static Uri GetSourceUri(DependencyObject obj){
			return (Uri)obj.GetValue(SourceUriProperty);
		}
		public static void SetSourceUri(DependencyObject obj, Uri value){
			obj.SetValue(SourceUriProperty, value);
		}
        public static readonly DependencyProperty SourceUriProperty =
			DependencyProperty.RegisterAttached("SourceUri",
				typeof(Uri),
				typeof(ImageAsyncHelper),
				new PropertyMetadata { PropertyChangedCallback = (obj, e) =>
					((Image)obj).SetBinding(
						Image.SourceProperty,
						new Binding("VerifiedUri"){
							Source = new ImageAsyncHelper{
								_givenUri = (Uri)e.NewValue
							},
							IsAsync = true
						}
					)
				}
			);
        private Uri _givenUri;
        public Uri VerifiedUri {
            get {
                try {
                    System.Net.Dns.GetHostEntry(_givenUri.DnsSafeHost);
                    return _givenUri;
                }
                catch (Exception) {
                    return null;
                }
            }
        }
    }
