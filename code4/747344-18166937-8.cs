     // on selection:
     TreeViewItem item = (TreeViewItem)sender;
     if(_currentControl != null)
     {
        // if the _currentControl supports the IRequestClose interface:
        if(_currentControl is IRequestClose)
            // cast the _currentControl to IRequestCode and call the RequestClose method.
            if(!((IRequestClose)_currentControl).RequestClose())
                 // now the usercontrol decides whether the control is closed/disposed or not.
                 return;
        _currentControl.Controls.Remove(_currentControl);
        _currentControl.Dispose();
     }
     if (item.Tag == null)
       return;
    _currentControl = (UserControl)Activator.Create(item.Tag);
    Panel1.Controls.Add(_currentControl);
