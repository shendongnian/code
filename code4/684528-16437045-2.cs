    labels = labels.ConvertAll<Control>(GetIdFromLabel);
    labels.Sort((x, y) => { return x.Id.CompareTo(y.Id); });
    public Control GetIdFromLabel(Control c)
        {
            c.Id = c.Name.Replace("Label", "") == "" ? 0 : Convert.ToInt32(c.Name.Replace("Label", ""));
            return c;
        }
