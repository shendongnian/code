    Parallel.For(0, results.Count, i =>
    	this.Dispatcher.BeginInvoke(new Action(() =>
    		{
    			product p = new product();
    			Common.SelectedOldColor = p.Background;
    			p.VideoInfo = results[i];
    			Common.Products.Add(p, false);
    			p.Visibility = System.Windows.Visibility.Hidden;
    			p.Drop_Event += new product.DragDropEvent(p_Drop_Event);
    			main.Children.Add(p);
    		})));
