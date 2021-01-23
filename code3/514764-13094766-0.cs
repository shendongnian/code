        public void AddLink(XElement element)
        {
            var link = element.Attribute("href").Value;
            InlineUIContainer uc = new InlineUIContainer();
            TextBlock tb = new TextBlock();
            tb.Margin = new Thickness(0, 0, 0, 0);
            var run = new Run();
            run.Text = element.Value;
            tb.Inlines.Add(run);
            tb.Tapped += (s, e) =>
            {
                Launcher.LaunchUriAsync(new Uri(link, UriKind.Absolute));
            };
            uc.Child = tb;
            paragraph.Inlines.Add(uc);
        }
