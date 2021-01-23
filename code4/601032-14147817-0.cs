    public static bool containsDuplicates(IList<ComboBox> boxes)
    {
        return boxes.Count != 
            boxes.Select(box => box.SelectedValue) //TODO cast if needed, or use some other property
            .Distinct()
            .Count();
    }
