    ListBox lb = new ListBox() { Name = "statusBox" };
    lb.ItemTemplate = this.listBoxTemplate;
    List<status> list = new List<status>();
    status aStatus = new status() { time = "3:00pm", statusText = "this is a status" };
    list.Add(aStatus);
    list.Add(new status() { time = "4:00pm", statusText = "this is another status" });
    lb.ItemsSource = list;
    this.ContentPanel.Children.Add(lb);
