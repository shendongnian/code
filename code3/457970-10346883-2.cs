    public static ArrayList GetRidOfTheSmallWidgets(ArrayList colBoxesOfWidgets)
    {
        foreach (BoxOfWidgets w in colBoxesOfWidgets)
        {
            Widget[] warr = w.colWidgets.OfType<Widget>().ToArray();
            for (int i = 0; i < warr.Length; i++)
            {
                if (warr[i].length < 20)
                w.colWidgets.Remove(warr[i]);
            }
        }
        return colBoxesOfWidgets;
    }
