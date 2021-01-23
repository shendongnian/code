    public static class VHAttribExtensions
    {
      public static string ToNameString(this VertebralHeight target)
      {
        return Enum.GetName(typeof(VertebralHeight), target);
      }
      public static double ToHeightValue(this VertebralHeight target)
      {
        var fi = target.GetType().GetField(target.ToString());
        var attributes = (VertebralHeightAsDoubleAttribute[])fi.GetCustomAttributes(
          typeof(VertebralHeightAsDoubleAttribute), false);
        return attributes.Length > 0 ? attributes[0].HeightValue : double.NaN;
      }
    }
