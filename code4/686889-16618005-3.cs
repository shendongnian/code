    var container = new ManuallyScrollableContainer();
    var content = new ExampleContent();
    container.Content = content;
    container.TotalContentWidth = 150000;
    container.TotalContentHeight = 5000;
    container.Dock = DockStyle.Fill;
    this.Controls.Add(container); // e.g. add to Form
