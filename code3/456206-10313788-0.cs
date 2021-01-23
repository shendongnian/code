    if (JIMSCanvas.Children.Any(c => c.Uid == ctrl.Uid)
    {
       MessageBox.Show("Already"); 
    }
    else
    {
       JIMSCanvas.Children.Add(ctrl); 
    }
