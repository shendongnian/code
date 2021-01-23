    public void delete(object parameter)
    {
        foreach (var x in Book.ToList())
        {
            if (x.Ischeck == true)
            {
                Book.Remove(x);
            }
        }
    } 
