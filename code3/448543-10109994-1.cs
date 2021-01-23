    public static void ClearAllTabPages(this TabControl tc, EventHandler eh)
    {
      tc.SelectedIndexChanged -= eh;
      try
      {
          tc.TabPages.Clear();
      }
      finally
      {
          tc.SelectedIndexChanged += eh;
      }
    }
