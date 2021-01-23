     private void Button_Click(object sender, RoutedEventArgs e)
        {            
            start = Int32.Parse(from.Text);
            end = Int32.Parse(to.Text);
            fake = items[start];
            //items.Insert(end, fake);
            this.Dispatcher.BeginInvoke(() =>
            {
                for (int i = 0; i < items.Count; ++i)
                {
                    var item = this.lb.ItemContainerGenerator.ContainerFromIndex(i) as ListBoxItem;
                    item.Name = i.ToString();
                }
                (this.lb.ItemContainerGenerator.ContainerFromIndex(end) as ListBoxItem).RenderTransform = new CompositeTransform();
                (this.lb.ItemContainerGenerator.ContainerFromIndex(end) as ListBoxItem).Name = "listBoxItem1";
                (this.lb.ItemContainerGenerator.ContainerFromIndex(start) as ListBoxItem).Name = "listBoxItem";
                sbListBox.Begin();
            });
            
        }
