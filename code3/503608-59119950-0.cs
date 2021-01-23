csharp
colorDialog1.CustomColors = ThemeColors.Select(x => ColorTranslator.ToOle(x)).ToArray()
The ThemeColors array would be something like this:
csharp
public static Color[] ThemeColors
{
   get => new[]
   {
      Color.FromArgb(255, 185, 0),
      Color.FromArgb(231, 72, 86),
      Color.FromArgb(0, 120, 215),
      Color.FromArgb(0, 153, 188),
      Color.DarkOrange
   }
}
*Note: Don't forget to add:*
csharp
using System.Linq;
