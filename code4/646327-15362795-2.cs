    public static class MenuStripExtensionMethods
    {
        public static IEnumerable<ToolStripItem> GetSubItems(this ToolStrip @this)
        {
            foreach (ToolStripItem child in @this.Items)
            {
                yield return child;
                foreach (var offspring in child.GetSubItems())
                    yield return offspring;
            }
        }
        public static IEnumerable<ToolStripItem> GetSubItems(this ToolStripItem @this)
        {
            if (!(@this is ToolStripDropDownItem))
                yield break;
            foreach (ToolStripItem child in ((ToolStripDropDownItem) @this).DropDownItems)
            {
                yield return child;
                foreach (var offspring in child.GetSubItems())
                    yield return offspring;
            }
        }
    }
