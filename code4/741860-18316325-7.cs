    public static class ThemeLib
    {
       public void DrawButton(Graphics g, Rectangle r, String text)
       {
          Sqm.AddToAverage("ThemeLib/DrawButton/TextLength", text.Length);
       }
    }
