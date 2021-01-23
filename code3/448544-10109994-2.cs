    public static void ClearAllTabPages(this TabControl tc, EventHandler eh)
    {
      tc.SelectedIndexChanged -= eh;
      tc.TabPages.Clear();
      tc.SelectedIndexChanged += eh;
    }
