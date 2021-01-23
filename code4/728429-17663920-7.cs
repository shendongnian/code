    private void BulletDecorator_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
    {
    	if ((e.OriginalSource is Border && ((Border)e.OriginalSource).Name == "chbStyleBorder") || (e.OriginalSource is Path && ((Path)e.OriginalSource).Name == "chbStyleCheckMark"))
    		e.Handled = false;
    	else
    		e.Handled = true;
    }
