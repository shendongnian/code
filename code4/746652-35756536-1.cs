    public static class Enum<T>
    {
        public static SelectListItem[] GetSelectItems()
        {
            Type type = typeof(T);
            return
                Enum.GetValues(type)
                    .Cast<object>()
                    .Select(v => new SelectListItem() { Value = v.ToString(), Text = Enum.GetName(type, v) })
                    .ToArray();
        }
    }
