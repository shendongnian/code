    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Net;
    using System.Text.RegularExpressions;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Documents;
    using System.Windows.Input;
    using System.Windows.Media;
    using System.Windows.Media.Animation;
    using System.Windows.Shapes;
    public static class RichTextBlockExtensions
    {
        public static void SetLinkedText(this RichTextBlock richTextBlock, string htmlFragment)
        {
            var regEx = new Regex(
                @"\<a\s(href\=""|[^\>]+?\shref\="")(?<link>[^""]+)"".*?\>(?<text>.*?)(\<\/a\>|$)",
                RegexOptions.IgnoreCase | RegexOptions.Multiline);
            richTextBlock.Blocks.Clear();
            int nextOffset = 0;
            foreach (Match match in regEx.Matches(htmlFragment))
            {
                if (match.Index > nextOffset)
                {
                    richTextBlock.AppendText(htmlFragment.Substring(nextOffset, match.Index - nextOffset));
                    nextOffset = match.Index + match.Length;
                    richTextBlock.AppendLink(match.Groups["text"].Value, new Uri(match.Groups["link"].Value));
                }
                Debug.WriteLine(match.Groups["text"] + ":" + match.Groups["link"]);
            }
            if (nextOffset < htmlFragment.Length)
            {
                richTextBlock.AppendText(htmlFragment.Substring(nextOffset));
            }
        }
        public static void AppendText(this RichTextBlock richTextBlock, string text)
        {
            Paragraph paragraph;
            if (richTextBlock.Blocks.Count == 0 ||
                (paragraph = richTextBlock.Blocks[richTextBlock.Blocks.Count - 1] as Paragraph) == null)
            {
                paragraph = new Paragraph();
                richTextBlock.Blocks.Add(paragraph);
            }
            paragraph.Inlines.Add(new Run { Text = text });
        }
        public static void AppendLink(this RichTextBlock richTextBlock, string text, Uri uri)
        {
            Paragraph paragraph;
            if (richTextBlock.Blocks.Count == 0 ||
                (paragraph = richTextBlock.Blocks[richTextBlock.Blocks.Count - 1] as Paragraph) == null)
            {
                paragraph = new Paragraph();
                richTextBlock.Blocks.Add(paragraph);
            }
            var run = new Run { Text = text };
            var link = new Hyperlink { NavigateUri = uri };
            link.Inlines.Add(run);
            paragraph.Inlines.Add(link);
        }
    }
    public partial class MainPage : UserControl
    {
        public MainPage()
        {
            InitializeComponent();
            this.richTextBlock.SetLinkedText(
                "Download it directly to the <a href=\"http://itunes.apple.com/fi/app/goalapp/id502461189?ls=1&mt=8\">iTunes Store</a> or <a href=\"https://market.android.com/details?id=com.strikersoft.meramal.se\">Android Market</a>. The application is launched for Swedish app store.");
        }
    }
