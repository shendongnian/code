    private void AddValidatableItem<T>(T item, List<T> list)
       where T : IValidatable
    {
        string outputError;
        if (!item.IsValid(out outputError))
        {
            MessageBox.Show(outputError);
            return;
        }
        if (list.Contains(item))
        {
            MessageBox.Show("ERROR 82ha5jb :: Item already exists");
            return;
        }
       
        list.Add(item);       
    }
