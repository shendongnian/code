    using System;
    using System.Drawing;
    using System.Globalization;
    using System.Runtime.InteropServices;
    
    class DwmManager
    {
       private struct DWM_COLORIZATION_PARAMS
       {
          public uint clrColor;
          public uint clrAfterGlow;
          public uint nIntensity;
          public uint clrAfterGlowBalance;
          public uint clrBlurBalance;
          public uint clrGlassReflectionIntensity;
          public bool fOpaque;
       }
    
       [DllImport("dwmapi.dll", EntryPoint = "#127", PreserveSig = false)]
       private static extern void DwmGetColorizationParameters(out DWM_COLORIZATION_PARAMS parameters);
    
       [DllImport("dwmapi.dll", EntryPoint = "#131", PreserveSig = false)]
       private static extern void DwmSetColorizationParameters(ref DWM_COLORIZATION_PARAMS parameters,
                                                               bool unknown);
    
       // Helper method to convert from a Win32 BGRA-format color to a .NET color.
       private static Color BgraToColor(uint color)
       {
          return Color.FromArgb(Int32.Parse(color.ToString("X"), NumberStyles.HexNumber));
       }
    
       // Helper method to convert from a .NET color to a Win32 BGRA-format color.
       private static uint ColorToBgra(Color color)
       {
          return (uint)(color.B | (color.G << 8) | (color.R << 16) | (color.A << 24));
       }
    
       // Gets or sets the current color used for DWM glass, based on the user's color scheme.
       public static Color ColorizationColor
       {
          get
          {
             // Call the DwmGetColorizationParameters function to fill in our structure.
             DWM_COLORIZATION_PARAMS parameters;
             DwmGetColorizationParameters(out parameters);
    
             // Convert the colorization color to a .NET color and return it.
             return BgraToColor(parameters.clrColor);
          }
          set
          {
             // Retrieve the current colorization parameters, just like we did above.
             DWM_COLORIZATION_PARAMS parameters;
             DwmGetColorizationParameters(out parameters);
    
             // Then modify the colorization color.
             // Note that the other parameters are left untouched, so they will stay the same.
             // You can also modify these; that is left as an exercise.
             parameters.clrColor = ColorToBgra(value);
    
             // Call the DwmSetColorizationParameters to make the change take effect.
             DwmSetColorizationParameters(ref parameters, false);
          }
       }
    }
    
