    public static void RemoveCssClass(this WebControl controlInstance, string css)
            {
                controlInstance.CssClass = string.Join(" ", controlInstance.CssClass.Split(' ').Where(x => x != css).ToArray());
            }
        public static void AddCssClass(this WebControl controlInstance, string css)
        {
            controlInstance.CssClass = string.Join($" {css} ", controlInstance.CssClass.Split(' ').ToArray());
        }
