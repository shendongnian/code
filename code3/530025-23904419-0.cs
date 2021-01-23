    private void listResize<T>(List<T> list, int size)
    {
       if (size > list.Count)
          while (size - list.Count > 0)
             list.Add(default<T>);    
       else if (size < list.Count)
          while (list.Count - size > 0)
             list.RemoveAt(list.Count-1);
    }
