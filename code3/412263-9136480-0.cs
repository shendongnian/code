    StringBuilder sb = new StringBuilder();
    foreach (HtmlNode cell in cells3)
    {
        sb.AppendLine(cell.InnerText);
    }
    Dispatcher.BeginInvoke(() => textBlock4.Text = sb.ToString());
    sb.Clear();
    // reuse sb for the following loops as shown above
