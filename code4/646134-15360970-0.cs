    static void TrimEmptyLines(List<string> listToModify)
    {
      if (listToModify == null)
        throw new ArgumentNullException();
      int last = listToModify.FindLastIndex(HasContent);
      if (last == -1)
      {
        // no lines have content
        listToModify.Clear();
        return;
      }
      int count = listToModify.Count - last - 1;
      if (count > 0)
        listToModify.RemoveRange(last + 1, count);
      int first = listToModify.FindIndex(HasContent);
      if (first > 0)
        listToModify.RemoveRange(0, first);
    }
