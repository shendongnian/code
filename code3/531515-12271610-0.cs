    protected override void Render(HtmlTextWriter writer)
    {
        var sb = new StringBuilder();
        using (var sw = new StringWriter(sb))
        {
            using (var htw = new HtmlTextWriter(sw))
            {
                base.Render(htw);
                writer.Write(sb.ToString());
                if (okayToEmail)
                {
                    using (var message = new MailMessage())
                    {
                        message.Body = sb.ToString();
                        ...
                    }
                }
            }
        }
    }
