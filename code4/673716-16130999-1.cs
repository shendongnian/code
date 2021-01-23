    public static List<Color> ColorStructToList()
    {
        return typeof(Color).GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public)
                            .Select(c => (Color)c.GetValue(null, null))
                            .ToList();
    }
List<Color> colorList = ColorStructToList();
----------
    private void randomBackgroundColorButton_Click(object sender, EventArgs e)
    {
        List<Color> myList = ColorStructToList();
        Random random = new Random();
        Color color = myList[random.Next(myList.Count - 1)];
        this.BackColor = color;
    }
    
    public static List<Color> ColorStructToList()
    {
        return typeof(Color).GetProperties(BindingFlags.Static | BindingFlags.DeclaredOnly | BindingFlags.Public)
                            .Select(c => (Color)c.GetValue(null, null))
                            .ToList();
    }
