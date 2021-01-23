    using System;
    using System.Diagnostics.CodeAnalysis;
    using System.Runtime.InteropServices;
    using System.Windows;
    using System.Windows.Interop;
    using System.Windows.Media;
    
    /// <summary>
    /// C Enumerator to Represent Special Window Handles
    /// </summary>
    public enum SpecialWindowHandles {
      kHwndTop = 0,
      kHwndBottom = 1,
      kHwndTopmost = -1,
      kHwndNotopmost = -2
    }
    
    /// <summary>
    /// C Enumerator to Set Window Position Flags
    /// </summary>
    public enum SetNativeWindowPosition {
      kNoSize = 0x0001,
      kNoMove = 0x0002,
      kNoZOrder = 0x0004,
      kNoRedraw = 0x0008,
      kNoActivate = 0x0010,
      kDrawFrame = 0x0020,
      kFrameChanged = 0x0020,
      kShowWindow = 0x0040,
      kHideWindow = 0x0080,
      kNoCopyBits = 0x0100,
      kNoOwnerZOrder = 0x0200,
      kNoReposition = 0x0200,
      kNoSendChanging = 0x0400,
      kDeferErase = 0x2000,
      kAsyncWindowPos = 0x4000
    }
    
    /// <summary>
    /// Class to perform Window Resize Animations
    /// </summary>
    public class NativeWindowSizeManager {
      #region Member Variables
      /// <summary>
      /// Attached Dependency Property for Native Window Height
      /// </summary>
      public static readonly
        DependencyProperty NativeWindowHeightProperty = DependencyProperty.RegisterAttached(
          "NativeWindowHeight",
          typeof(double),
          typeof(Window),
          new PropertyMetadata(OnNativeDimensionChanged));
    
      /// <summary>
      /// Attached Dependency Property for Native Window Width
      /// </summary>
      public static readonly
        DependencyProperty NativeWindowWidthProperty = DependencyProperty.RegisterAttached(
          "NativeWindowWidth",
          typeof(double),
          typeof(Window),
          new PropertyMetadata(OnNativeDimensionChanged));
    
      /// <summary>
      /// Attached Dependency Property for Native Window Left
      /// </summary>
      public static readonly
        DependencyProperty NativeWindowLeftProperty = DependencyProperty.RegisterAttached(
          "NativeWindowLeft",
          typeof(double),
          typeof(Window),
          new PropertyMetadata(OnNativeDimensionChanged));
    
      /// <summary>
      /// Attached Dependency Property for Native Window Top
      /// </summary>
      public static readonly
        DependencyProperty NativeWindowTopProperty = DependencyProperty.RegisterAttached(
          "NativeWindowTop",
          typeof(double),
          typeof(Window),
          new PropertyMetadata(OnNativeDimensionChanged));
    
      /// <summary>
      /// Private member holding Dpi Factor
      /// </summary>
      private static double? _dpiFactor;
      #endregion
    
      #region Constructors
      #endregion
    
      #region Commands & Properties
      #endregion
    
      #region Methods
      /// <summary>
      /// Sets the native height.
      /// </summary>
      /// <param name="element">The element.</param>
      /// <param name="value">The value.</param>
      public static void SetNativeWindowHeight(UIElement element, double value) {
        element.SetValue(NativeWindowHeightProperty, value);
      }
    
      /// <summary>
      /// Gets the native height.
      /// </summary>
      /// <param name="element">The element.</param>
      /// <returns>Native Height in pixels</returns>
      public static double GetNativeWindowHeight(UIElement element) {
        return (double)element.GetValue(NativeWindowHeightProperty);
      }
    
      /// <summary>
      /// Sets the native width.
      /// </summary>
      /// <param name="element">The element.</param>
      /// <param name="value">The value.</param>
      public static void SetNativeWindowWidth(UIElement element, double value) {
        element.SetValue(NativeWindowWidthProperty, value);
      }
    
      /// <summary>
      /// Gets the native width.
      /// </summary>
      /// <param name="element">The element.</param>
      /// <returns>Native Width in pixels</returns>
      public static double GetNativeWindowWidth(UIElement element) {
        return (double)element.GetValue(NativeWindowWidthProperty);
      }
    
      /// <summary>
      /// Sets the native left.
      /// </summary>
      /// <param name="element">The element.</param>
      /// <param name="value">The value.</param>
      public static void SetNativeWindowLeft(UIElement element, double value) {
        element.SetValue(NativeWindowLeftProperty, value);
      }
    
      /// <summary>
      /// Gets the native left.
      /// </summary>
      /// <param name="element">The element.</param>
      /// <returns>Native Left in pixels</returns>
      public static double GetNativeWindowLeft(UIElement element) {
        return (double)element.GetValue(NativeWindowLeftProperty);
      }
    
      /// <summary>
      /// Sets the native top.
      /// </summary>
      /// <param name="element">The element.</param>
      /// <param name="value">The value.</param>
      public static void SetNativeWindowTop(UIElement element, double value) {
        element.SetValue(NativeWindowTopProperty, value);
      }
    
      /// <summary>
      /// Gets the native top.
      /// </summary>
      /// <param name="element">The element.</param>
      /// <returns>Native Top in pixels</returns>
      public static double GetNativeWindowTop(UIElement element) {
        return (double)element.GetValue(NativeWindowTopProperty);
      }
    
      /// <summary>
      /// Method to Get Dpi Factor
      /// </summary>
      /// <param name="window">Window Object</param>
      /// <returns>Dpi Factor</returns>
      public static double GetDpiFactor(Visual window) {
        HwndSource windowHandleSource = PresentationSource.FromVisual(window) as HwndSource;
        if (windowHandleSource != null && windowHandleSource.CompositionTarget != null) {
          Matrix screenmatrix = windowHandleSource.CompositionTarget.TransformToDevice;
          return screenmatrix.M11;
        }
    
        return 1;
      }
    
      /// <summary>
      /// Method to Retrieve Dpi Factor for Window
      /// </summary>
      /// <param name="window">Requesting Window</param>
      /// <param name="originalValue">Dpi Independent Unit</param>
      /// <returns>Pixel Value</returns>
      private static int ConvertToDpiDependentPixels(Visual window, double originalValue) {
        if (_dpiFactor == null) {
          _dpiFactor = GetDpiFactor(window);
        }
    
        return (int)(originalValue * _dpiFactor);
      }
    
      /// <summary>
      /// Handler For all Attached Native Dimension property Changes
      /// </summary>
      /// <param name="obj">Dependency Object</param>
      /// <param name="e">Property Arguments</param>
      private static void OnNativeDimensionChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e) {
        var window = obj as Window;
        if (window == null)
          return;
    
        IntPtr handle = new WindowInteropHelper(window).Handle;
        var rect = new Rect();
        if (!GetWindowRect(handle, ref rect))
          return;
    
        rect.X = ConvertToDpiDependentPixels(window, window.Left);
        rect.Y = ConvertToDpiDependentPixels(window, window.Top);
        rect.Width = ConvertToDpiDependentPixels(window, window.ActualWidth);
        rect.Height = ConvertToDpiDependentPixels(window, window.ActualHeight);
    
        if (e.Property == NativeWindowHeightProperty) {
          rect.Height = ConvertToDpiDependentPixels(window, (double)e.NewValue);
        } else if (e.Property == NativeWindowWidthProperty) {
          rect.Width = ConvertToDpiDependentPixels(window, (double)e.NewValue);
        } else if (e.Property == NativeWindowLeftProperty) {
          rect.X = ConvertToDpiDependentPixels(window, (double)e.NewValue);
        } else if (e.Property == NativeWindowTopProperty) {
          rect.Y = ConvertToDpiDependentPixels(window, (double)e.NewValue);
        }
    
        SetWindowPos(
          handle,
          new IntPtr((int)SpecialWindowHandles.kHwndTop),
          rect.X,
          rect.Y,
          rect.Width,
          rect.Height,
          (uint)SetNativeWindowPosition.kShowWindow);
      }
      #endregion
    
      #region Native Helpers
      [DllImport("user32.dll", SetLastError = true)]
      private static extern bool GetWindowRect(IntPtr windowHandle, ref Rect rect);
    
      [DllImport("user32.dll")]
      [return: MarshalAs(UnmanagedType.Bool)]
      private static extern bool SetWindowPos(
        IntPtr windowHandle, IntPtr windowHandleInsertAfter, int x, int y, int cx, int cy, uint windowPositionFlag);
    
      /// <summary>
      /// C Structure To Represent Window Rectangle
      /// </summary>
      [SuppressMessage("Microsoft.StyleCop.CSharp.DocumentationRules", "SA1600:ElementsMustBeDocumented",
        Justification = "This is an Implementation for C Struct")]
      [StructLayout(LayoutKind.Sequential)]
      public struct Rect {
        public int X;
        public int Y;
        public int Width;
        public int Height;
      }
      #endregion
    }
