    using System;
    using System.IO;
    using System.Windows;
    using ImageTools;
    using ImageTools.IO;
    using ImageTools.IO.Gif;
    
    namespace GifViewer.ViewModels {
        public class MainViewModel : DependencyObject {
            public MainViewModel() {
                Decoders.AddDecoder<GifDecoder>();
                Uri uri = new Uri("Gif/explosion.gif", UriKind.Relative);
                ExtendedImage image = new ExtendedImage();
                // either of these two method work.
                // Just remove the first / to switch
                //*
                image.LoadingCompleted +=
                    (o, e) => Dispatcher.BeginInvoke(() => AnimationImage = image);
                image.UriSource = uri;
                /*/
                Stream stream = Application.GetResourceStream(uri).Stream;
                GifDecoder decoder = new GifDecoder();
                decoder.Decode(image, stream);
                AnimationImage = image;
                /**/
            }
    
            public static readonly DependencyProperty AnimationImageProperty =
                DependencyProperty.Register("AnimationImage",
                    typeof(ExtendedImage),
                    typeof(MainViewModel),
                    new PropertyMetadata(default(ExtendedImage)));
    
            public ExtendedImage AnimationImage {
                get { return (ExtendedImage)GetValue(AnimationImageProperty); }
                set { SetValue(AnimationImageProperty, value); }
            }
        }
    }
