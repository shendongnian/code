    private static void Test<T>()
        where T : Form
    {
        foreach (Form f in Application.OpenForms)
        {
            if (f is T)
            {
            }
        }
    }
