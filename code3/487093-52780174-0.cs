      public static class EnumerableExtension
    {
        public static string ToHtmlTable<T>(this IEnumerable<T> list, List<string> headerList, List<CustomTableStyle> customTableStyles, params Func<T, object>[] columns)
        {
            var tableCss = string.Join(' ', customTableStyles?.Where(w => w.CustomTableStylePosition == CustomTableStylePosition.Table).Where(w => w.ClassNameList != null).SelectMany(s => s.ClassNameList)) ?? "";
            var trCss = string.Join(' ', customTableStyles?.Where(w => w.CustomTableStylePosition == CustomTableStylePosition.Tr).Where(w => w.ClassNameList != null).SelectMany(s => s.ClassNameList)) ?? "";
            var thCss = string.Join(' ', customTableStyles?.Where(w => w.CustomTableStylePosition == CustomTableStylePosition.Th).Where(w => w.ClassNameList != null).SelectMany(s => s.ClassNameList)) ?? "";
            var tdCss = string.Join(' ', customTableStyles?.Where(w => w.CustomTableStylePosition == CustomTableStylePosition.Td).Where(w => w.ClassNameList != null).SelectMany(s => s.ClassNameList)) ?? "";
            var tableInlineCss = string.Join(';', customTableStyles?.Where(w => w.CustomTableStylePosition == CustomTableStylePosition.Table).Where(w => w.InlineStyleValueList != null).SelectMany(s => s.InlineStyleValueList?.Select(x => String.Format("{0}:{1}", x.Key, x.Value)))) ?? "";
            var trInlineCss = string.Join(';', customTableStyles?.Where(w => w.CustomTableStylePosition == CustomTableStylePosition.Tr).Where(w => w.InlineStyleValueList != null).SelectMany(s => s.InlineStyleValueList?.Select(x => String.Format("{0}:{1}", x.Key, x.Value)))) ?? "";
            var thInlineCss = string.Join(';', customTableStyles?.Where(w => w.CustomTableStylePosition == CustomTableStylePosition.Th).Where(w => w.InlineStyleValueList != null).SelectMany(s => s.InlineStyleValueList?.Select(x => String.Format("{0}:{1}", x.Key, x.Value)))) ?? "";
            var tdInlineCss = string.Join(';', customTableStyles?.Where(w => w.CustomTableStylePosition == CustomTableStylePosition.Td).Where(w => w.InlineStyleValueList != null).SelectMany(s => s.InlineStyleValueList?.Select(x => String.Format("{0}:{1}", x.Key, x.Value)))) ?? "";
            var sb = new StringBuilder();
            sb.Append($"<table{(string.IsNullOrEmpty(tableCss) ? "" : $" class=\"{tableCss}\"")}{(string.IsNullOrEmpty(tableInlineCss) ? "" : $" style=\"{tableInlineCss}\"")}>");
            sb.Append($"<tr{(string.IsNullOrEmpty(trCss) ? "" : $" class=\"{trCss}\"")}{(string.IsNullOrEmpty(trInlineCss) ? "" : $" style=\"{trInlineCss}\"")}>");
            foreach (var header in headerList)
            {
                sb.Append($"<th{(string.IsNullOrEmpty(thCss) ? "" : $" class=\"{thCss}\"")}{(string.IsNullOrEmpty(thInlineCss) ? "" : $" style=\"{thInlineCss}\"")}>{header}</th>");
            }
            sb.Append("</tr>");
            foreach (var item in list)
            {
                sb.Append($"<tr{(string.IsNullOrEmpty(trCss) ? "" : $" class=\"{trCss}\"")}{(string.IsNullOrEmpty(trInlineCss) ? "" : $" style=\"{trInlineCss}\"")}>");
                foreach (var column in columns)
                    sb.Append($"<td{(string.IsNullOrEmpty(tdCss) ? "" : $" class=\"{tdCss}\"")}{(string.IsNullOrEmpty(tdInlineCss) ? "" : $" style=\"{tdInlineCss}\"")}>{column(item)}</td>");
                sb.Append("</tr>");
            }
            sb.Append("</table>");
            return sb.ToString();
        }
        public class CustomTableStyle
        {
            public CustomTableStylePosition CustomTableStylePosition { get; set; }
            public List<string> ClassNameList { get; set; }
            public Dictionary<string, string> InlineStyleValueList { get; set; }
        }
        public enum CustomTableStylePosition
        {
            Table,
            Tr,
            Th,
            Td
        }
    }
