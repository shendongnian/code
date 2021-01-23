    public static class TabControlExtender
    {
        public static void Remove(this TabControl t, string name)
        {
            var tabPage = t.TabPages.OfType<TabPage>()
                .FirstOrDefault(o => o.Name == name);
            if (tabPage != null)
            {
                t.TabPages.Remove(tabPage);
            }
        }
    }
