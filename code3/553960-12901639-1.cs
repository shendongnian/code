    public void HandleNavigaitionEvent(object sender, string pageName, Frame AppFrame, StackPanel stack)
            {
                var content = Pages.Where(i => i.Name == pageName).FirstOrDefault();
                NavigateTrigger(AppFrame, content);
            }
    public void NavigateTrigger(Frame AppFrame, LayoutAwarePage content)
            {
                EventAggregator.GetEvent<PageNavigatedEvent>().Publish(content);
                AppFrame.Content = content;
                NaviagationPath.Add(content);
            }
