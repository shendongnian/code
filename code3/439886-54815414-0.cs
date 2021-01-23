dotnet add package iTextSharp
Collected all bookmarks with the following code:
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using iTextSharp.text.pdf;
namespace PdfManipulation
{
    class Program
    {
        static void Main(string[] args)
        {
            StringBuilder bookmarks = ExtractAllBookmarks("myPdfFile.pdf");
        }
        private static StringBuilder ExtractAllBookmarks(string pdf)
        {
            StringBuilder sb = new StringBuilder();
            PdfReader reader = new PdfReader(pdf);
            IList<Dictionary<string, object>> bookmarksTree = SimpleBookmark.GetBookmark(reader);
            foreach (var node in bookmarksTree)
            {
                sb.AppendLine(PercorreBookmarks(node).ToString());
            }
            return RemoveAllBlankLines(sb);
        }
        private static StringBuilder RemoveAllBlankLines(StringBuilder sb)
        {
            return new StringBuilder().Append(Regex.Replace(sb.ToString(), @"^\s+$[\r\n]*", string.Empty, RegexOptions.Multiline));
        }
        private static StringBuilder PercorreBookmarks(Dictionary<string, object> bookmark)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine(bookmark["Title"].ToString());
            if (bookmark != null && bookmark.ContainsKey("Kids"))
            {
                IList<Dictionary<string, object>> children = (IList<Dictionary<string, object>>) bookmark["Kids"];
                foreach (var bm in children)
                {
                    sb.AppendLine(PercorreBookmarks(bm).ToString());
                }
            }
            return sb;
        }
    }
}
