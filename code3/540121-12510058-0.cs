    public static string ToHtml ( System.Drawing.Color color )
    {
       if (System.Drawing.Color.Transparent == color)
          return "Transparent";
       return string.Concat("#", (color.ToArgb() & 0x00FFFFFF).ToString("X6"));
    }
