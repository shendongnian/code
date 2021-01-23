    bool alreadyExists = false;
    UIElement existingElement = null;
    foreach (UIElement child in JIMSCanvas.Children)
    {
        if (child.Uid == ctrl.Uid)
        {
            alreadyExists = true;
            existingElement = child;
        }
    }
    if (alreadyExists)
    {
        MessageBox.Show("Already");
        existingElement.Visibility = System.Windows.Visibility.Visible;
    }
    else
    {
        JIMSCanvas.Children.Add(ctrl);
    }
