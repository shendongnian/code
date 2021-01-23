    public static void TheMethod(ICollection<IDictionary<string, string>> d)
        {
            MessageBox.Show(d.Count);
            // Other processing
        }
    public static void MyMethod(string s)
        {
            TheMethod("name, value", "otherName, otherValue");
        }
