    public static class UtilitiesX {
        public static IEnumerable<Control> GetEntireControlsTree(this Control rootControl)
        {
            yield return rootControl;
            foreach (var childControl in rootControl.Controls.Cast<Control>().SelectMany(x => x.GetEntireControlsTree()))
            {
                yield return childControl;
            }
        }
        public static void ForEach<T>(this IEnumerable<T> en, Action<T> action)
        {
            foreach (var obj in en) action(obj);
        }
    }
