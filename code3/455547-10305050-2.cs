    using System;
    using System.Diagnostics;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Media;
    using System.Windows.Media.Imaging;
    
    namespace ColorWheel
    {
        /// <summary>
        ///   Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
            }
    
            private void BuildWheel()
            {
                var width = 1024;
                var height = width;
                var cx = width/2;
                var cy = height/2;
                var colors = new int[width*height];
                var gray = Colors.Gray.ToBgr32();
                for (int index = 0; index < colors.Length; index++) colors[index] = gray;
    
                var radius = cx;
                var radiusSquared = radius*radius;
                for (int i = 0; i < height; i++)
                {
                    for (int j = 0; j < width; j++)
                    {
                        var x = j - cx;
                        var y = i - cy;
                        var distanceSquared = (double) x*x + y*y;
                        if (distanceSquared <= radiusSquared) // In circle
                        {
                            var h = Math.Atan2(x, y).ToDegrees() + 180.0d; // Angle
                            var s = 1.0d;
                            var l = (1.0d - ((1.0d/radiusSquared)*distanceSquared)); // 1 - (distance normalized)
                            var hsl = new HSL((float) h, (float) s, (float) l);
                            var rgb = RGB.FromHsl(hsl.H, hsl.S, hsl.L);
                            colors[i*width + j] = rgb.R << 16 | rgb.G << 8 | rgb.B;
                        }
                    }
                }
                var bitmap = new WriteableBitmap(width, height, 96, 96, PixelFormats.Bgr32, null);
                bitmap.WritePixels(new Int32Rect(0, 0, width, height), colors, width*4, 0);
                image.Source = bitmap;
            }
    
            private void Window_Loaded(object sender, RoutedEventArgs e)
            {
                BuildWheel();
            }
        }
    
        public static class Helpers
        {
            public static double ToDegrees(this double radians)
            {
                return radians*57.2957795130823; // radians * (180.0d / Math.PI)
            }
    
            public static double ToRadians(this double degrees)
            {
                return degrees*0.0174532925199433; // degrees * (Math.PI / 180.0d)
            }
        }
    
        public static class ColorExtensions
        {
            public static Color FromBgr32(this Int32 color)
            {
                return Color.FromRgb((byte) ((color & 0xFF0000) >> 16), (byte) ((color & 0xFF00) >> 8), (byte) (color & 0xFF));
            }
    
            public static int ToBgr32(this Color color)
            {
                return color.R << 16 | color.G << 8 | color.B;
            }
        }
    
        /// <summary>
        ///   Represents a color in an HSL space.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct HSL
        {
            [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly double _h;
    
            [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly double _s;
    
            [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly double _l;
    
            /// <summary>
            ///   Returns the fully qualified type name of this instance.
            /// </summary>
            /// <returns> A <see cref="T:System.String" /> containing a fully qualified type name. </returns>
            /// <filterpriority>2</filterpriority>
            public override string ToString()
            {
                return string.Format("H: {0}, S: {1}, L: {2}", _h, _s, _l);
            }
    
            /// <summary>
            ///   Create a new instance of <see cref="HSL" /> .
            /// </summary>
            /// <param name="h"> Value of <see cref="H" /> component. </param>
            /// <param name="s"> Value of <see cref="S" /> component. </param>
            /// <param name="l"> Value of <see cref="L" /> component. </param>
            public HSL(double h, double s, double l)
            {
                _h = h;
                _s = s;
                _l = l;
            }
    
            /// <summary>
            ///   Gets the value of the hue component.
            /// </summary>
            public double H
            {
                get { return _h; }
            }
    
            /// <summary>
            ///   Gets the value of the saturation component.
            /// </summary>
            public double S
            {
                get { return _s; }
            }
    
            /// <summary>
            ///   Gets the value of the lightness component.
            /// </summary>
            public double L
            {
                get { return _l; }
            }
    
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (obj.GetType() != typeof (HSL)) return false;
                return Equals((HSL) obj);
            }
    
            public bool Equals(HSL other)
            {
                return other._h.Equals(_h) && other._l.Equals(_l) &&
                       other._s.Equals(_s);
            }
    
            /// <summary>
            ///   Create a new instance of <see cref="HSL" /> , from RGB values.
            /// </summary>
            /// <param name="red"> Value of the red component. </param>
            /// <param name="green"> Value of the green component. </param>
            /// <param name="blue"> Value of the blue component. </param>
            /// <returns> <see cref="HSL" /> instance created. </returns>
            public static HSL FromRGB(byte red, byte green, byte blue)
            {
                var r1 = red/255.0d;
                var g1 = green/255.0d;
                var b1 = blue/255.0d;
    
                var min = Math.Min(r1, Math.Min(g1, b1));
                var max = Math.Max(r1, Math.Max(g1, b1));
    
                var l = (max + min)/2.0d;
    
                var s = 0.0d;
                var h = 0.0d;
                if (min == max)
                {
                    h = 0.0d;
                    s = 0.0d;
                }
                else
                {
                    if (l < 0.5d)
                    {
                        s = (max - min)/(max + min);
                    }
                    else if (l >= 0.5d)
                    {
                        s = (max - min)/(2.0d - max - min);
                    }
    
                    if (r1 == max)
                    {
                        h = (g1 - b1)/(max - min);
                    }
                    else if (g1 == max)
                    {
                        h = 2.0d + (b1 - r1)/(max - min);
                    }
                    else if (b1 == max)
                    {
                        h = 4.0d + (r1 - g1)/(max - min);
                    }
                }
    
                h *= 60.0d;
    
                if (h < 0.0d)
                    h += 360.0d;
    
                return new HSL(h, s, l);
            }
    
            /// <summary>
            ///   Returns the hash code for this instance.
            /// </summary>
            /// <returns> A 32-bit signed integer that is the hash code for this instance. </returns>
            /// <filterpriority>2</filterpriority>
            public override int GetHashCode()
            {
                unchecked
                {
                    var result = _h.GetHashCode();
                    result = (result*397) ^ _l.GetHashCode();
                    result = (result*397) ^ _s.GetHashCode();
                    return result;
                }
            }
    
    
            public static BitmapSource GetHslPalette(int width = 360, int height = 100)
            {
                // Creates an HSL palette image like in Photoshop, etc ...
                var pixels = new int[width*height];
                const double saturation = 1.0d;
                for (var y = 0; y < height; y++)
                {
                    for (var x = 0; x < width; x++)
                    {
                        var hue = (1.0d/width)*x*360.0d;
                        var lightness = 1.0d - ((1.0f/height)*y);
                        var rgb = RGB.FromHsl(hue, saturation, lightness);
                        pixels[y*width + x] = 0xFF << 24 | rgb.R << 16 | rgb.G << 8 | rgb.B;
                    }
                }
                return BitmapSource.Create(width, height, 96, 96, PixelFormats.Pbgra32, null, pixels, width*4);
            }
    
            public static bool operator ==(HSL left, HSL right)
            {
                return left.Equals(right);
            }
    
            public static bool operator !=(HSL left, HSL right)
            {
                return !left.Equals(right);
            }
        }
    
        /// <summary>
        ///   Represents a color in an RGB space.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        public struct RGB
        {
            [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly byte _r;
    
            [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly byte _g;
    
            [DebuggerBrowsable(DebuggerBrowsableState.Never)] private readonly byte _b;
    
            /// <summary>
            ///   Create a new instance of <see cref="RGB" /> .
            /// </summary>
            /// <param name="r"> Value of red component. </param>
            /// <param name="g"> Value of green component. </param>
            /// <param name="b"> Value of blue component. </param>
            public RGB(byte r, byte g, byte b)
            {
                _r = r;
                _g = g;
                _b = b;
            }
    
            /// <summary>
            ///   Returns the fully qualified type name of this instance.
            /// </summary>
            /// <returns> A <see cref="T:System.String" /> containing a fully qualified type name. </returns>
            /// <filterpriority>2</filterpriority>
            public override string ToString()
            {
                return string.Format("R: {0}, G: {1}, B: {2}", _r, _g, _b);
            }
    
            /// <summary>
            ///   Gets the value of the red component.
            /// </summary>
            public byte R
            {
                get { return _r; }
            }
    
            /// <summary>
            ///   Gets the value of the green component.
            /// </summary>
            public byte G
            {
                get { return _g; }
            }
    
            /// <summary>
            ///   Gets the value of the blue component.
            /// </summary>
            public byte B
            {
                get { return _b; }
            }
    
            public override bool Equals(object obj)
            {
                if (ReferenceEquals(null, obj)) return false;
                if (obj.GetType() != typeof (RGB)) return false;
                return Equals((RGB) obj);
            }
    
            public bool Equals(RGB other)
            {
                return other._b == _b && other._g == _g && other._r == _r;
            }
    
            /// <summary>
            ///   Create a new instance of <see cref="RGB" /> , from HSL values.
            /// </summary>
            /// <param name="hue"> Hue, from 0.0 to 360.0. </param>
            /// <param name="saturation"> Saturation, from 0.0 to 1.0. </param>
            /// <param name="lightness"> Lightness, from 0.0 to 1.0. </param>
            /// <returns> <see cref="RGB" /> instance created. </returns>
            public static RGB FromHsl(double hue, double saturation, double lightness)
            {
                if (hue < 0.0d || hue > 360.0d) throw new ArgumentOutOfRangeException("hue");
                if (saturation < 0.0d || saturation > 1.0d) throw new ArgumentOutOfRangeException("saturation");
                if (lightness < 0.0d || lightness > 1.0d) throw new ArgumentOutOfRangeException("lightness");
    
                if (saturation == 0.0d)
                {
                    var b1 = (byte) (lightness*255);
                    return new RGB(b1, b1, b1);
                }
    
                var t2 = 0.0d;
    
                if (lightness < 0.5d)
                    t2 = lightness*(1.0d + saturation);
                else if (lightness >= 0.5d)
                    t2 = lightness + saturation - lightness*saturation;
    
                var t1 = 2.0d*lightness - t2;
    
                var h = hue/360.0d;
    
                var tr = h + 1.0d/3.0d;
                var tg = h;
                var tb = h - 1.0d/3.0d;
    
                tr = tr < 0.0d ? tr + 1.0d : tr > 1.0d ? tr - 1.0d : tr;
                tg = tg < 0.0d ? tg + 1.0d : tg > 1.0d ? tg - 1.0d : tg;
                tb = tb < 0.0d ? tb + 1.0d : tb > 1.0d ? tb - 1.0d : tb;
    
                double r;
                if (6.0d*tr < 1.0d)
                    r = t1 + (t2 - t1)*6.0d*tr;
                else if (2.0d*tr < 1.0d)
                    r = t2;
                else if (3.0d*tr < 2.0d)
                    r = t1 + (t2 - t1)*((2.0d/3.0d) - tr)*6.0d;
                else
                    r = t1;
    
                double g;
                if (6.0d*tg < 1.0d)
                    g = t1 + (t2 - t1)*6.0d*tg;
                else if (2.0d*tg < 1.0d)
                    g = t2;
                else if (3.0d*tg < 2.0d)
                    g = t1 + (t2 - t1)*((2.0d/3.0d) - tg)*6.0d;
                else
                    g = t1;
    
                double b;
                if (6.0d*tb < 1.0d)
                    b = t1 + (t2 - t1)*6.0d*tb;
                else if (2.0d*tb < 1.0d)
                    b = t2;
                else if (3.0d*tb < 2.0d)
                    b = t1 + (t2 - t1)*((2.0d/3.0d) - tb)*6.0d;
                else
                    b = t1;
    
                return new RGB((byte) (r*255), (byte) (g*255), (byte) (b*255));
            }
    
            /// <summary>
            ///   Returns the hash code for this instance.
            /// </summary>
            /// <returns> A 32-bit signed integer that is the hash code for this instance. </returns>
            /// <filterpriority>2</filterpriority>
            public override int GetHashCode()
            {
                unchecked
                {
                    var result = _b.GetHashCode();
                    result = (result*397) ^ _g.GetHashCode();
                    result = (result*397) ^ _r.GetHashCode();
                    return result;
                }
            }
    
            public static bool operator ==(RGB left, RGB right)
            {
                return left.Equals(right);
            }
    
            public static bool operator !=(RGB left, RGB right)
            {
                return !left.Equals(right);
            }
        }
    }
