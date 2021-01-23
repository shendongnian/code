        void link_MouseUp(object sender, HtmlElementEventArgs e)
        {
            Regex pattern = new Regex("href=\\\"(.+?)\\\"");
            Match match = pattern.Match((sender as HtmlElement).OuterHtml);
            string link = match.Groups[1].Value;
            Process.Start(link);
        }
