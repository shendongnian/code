    public static List<Label> FindLabelRecursive(Control root)
    {
        List<Label> labels = new List<Label>();
        if (root is Label)
        {
            labels.Add(root);
            return labels;
        }
        foreach(Control c in root.Controls)
        {
            if (c is Label)
            {
                labels.Add(c);
            }
            else
            {
                List<Label> childLabels = FindLabelRecursive(c);
                labels.AddRange(childLabels);
            }
        }
        return labels;
    }
