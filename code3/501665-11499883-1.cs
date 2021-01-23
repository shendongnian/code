    public class TextBoxStateTracker : Behavior<Panel>
    {
    private TextBox _previouslySelectedElement;
    private int _selectionStart;
    private int _selectionLength;
    protected override void OnAttached()
    {
    //after control and all its children are created find textboxes and buttons
        AssociatedObject.Initialized += (x, y) =>
            {
                var textBoxElements = FindChildren<TextBox>(AssociatedObject);
                foreach (var item in textBoxElements)
                {
                    item.LostFocus += new RoutedEventHandler(item_LostFocus);
                }
                var buttons = FindChildren<Button>(AssociatedObject);
                foreach (var item in buttons)
                {
                    item.Click += new RoutedEventHandler(item_Click);
                }
            };
    }
    private void item_Click(object sender, RoutedEventArgs e)
    {
        if (_previouslySelectedElement == null) return;
        //simply replace selected text in previously focused textbox with whatever is in tag property
        var button = (Button)sender;
        var textToInsert = (string)button.Tag;
        _previouslySelectedElement.Text = _previouslySelectedElement.Text.Substring(0, _selectionStart)
            + textToInsert +
            _previouslySelectedElement.Text.Substring(_selectionStart + _selectionLength);
        _previouslySelectedElement.Focus();
        _previouslySelectedElement.SelectionStart = _selectionStart + textToInsert.Length;
    }
    private void item_LostFocus(object sender, RoutedEventArgs e)
    {
        //this method is fired when textboxes loose their focus note that this
        //might not be fired by button click
        _previouslySelectedElement = (TextBox)sender;
        _selectionStart = _previouslySelectedElement.SelectionStart;
        _selectionLength = _previouslySelectedElement.SelectionLength;
    }
    public List<TChild> FindChildren<TChild>(DependencyObject d)
       where TChild : DependencyObject
    {
        List<TChild> children = new List<TChild>();
        int childCount = VisualTreeHelper.GetChildrenCount(d);
        for (int i = 0; i < childCount; i++)
        {
            DependencyObject o = VisualTreeHelper.GetChild(d, i);
            if (o is TChild)
                children.Add(o as TChild);
            foreach (TChild c in FindChildren<TChild>(o))
                children.Add(c);
        }
        return children;
    }
