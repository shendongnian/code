      public static void RemoveCssClass(this HtmlGenericControl controlInstance, string css)
        {
            var strCssClass = controlInstance.Attributes["class"];
            controlInstance.Attributes["class"] = string.Join(" ", strCssClass.Split(' ').Where(x => x != css).ToArray());
        }
        public static void AddCssClass(this HtmlGenericControl controlInstance, string css)
        {
            var strCssClass = controlInstance.Attributes["class"];
            controlInstance.Attributes["class"] = string.Join($" {css} ", strCssClass.Split(' ').ToArray());
        }
