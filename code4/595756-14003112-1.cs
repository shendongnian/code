    private void listboxMyTimeline_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            for (int i = 0; i < listboxMyTimeline.Items.Count; i++)
            {
                ListBoxItem lbi2 = (ListBoxItem)(listboxMyTimeline.ItemContainerGenerator.ContainerFromIndex(i));
                if (lbi2 != null)
                {
                    var ob = FindFirstElementInVisualTree<RichTextBox>(lbi2);
                    var ob2 = FindFirstElementInVisualTree<TextBlock>(lbi2);
                    ob.Xaml = ob2.Text;
                }
                else
                {
                    var itm = listboxMyTimeline.Items.ElementAt(i);
                    lbi2 = (ListBoxItem)(listboxMyTimeline.ItemContainerGenerator.ContainerFromItem(itm));
                    if (lbi2 != null)
                    {
                        var ob = FindFirstElementInVisualTree<RichTextBox>(lbi2);
                        var ob2 = FindFirstElementInVisualTree<TextBlock>(lbi2);
                        ob.Xaml = ob2.Text;
                    }
                }
            }
        }
