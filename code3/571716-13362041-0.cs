    private void HighlightText(Object itx)
    {
        //safety checks
        if (itx == null)
            return;        
        if (String.isNullOrEmpty(textBox1.Text)
            return; //just in case the box is empty
        if (! (itx is Visual || itx is System.Windows.Media.Media3D.Visual3D)
            return;  //prevent from getting children on non-visual element
        
        if (itx is TextBlock)
        {
            Regex regex = new Regex("(" + textBox1.Text + ")", RegexOptions.IgnoreCase);
            TextBlock tb = itx as TextBlock;
            tb.Inlines.Clear();
            if (textBox1.Text.Length == 0)
            {
                string str = tb.Text;
                tb.Inlines.Add(str);
                return;
            }
            string[] substrings = regex.Split(tb.Text);
            foreach (var item in substrings)
            {
                
                if (!regex.Match(item).Success)
                {
                    Run runx = new Run(item);
                    runx.Background = Brushes.LightGray;
                    tb.Inlines.Add(runx);
                }
                else
                {
                    tb.Inlines.Add(item);
                }
            }
            return;
        }
        else
        {
            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(itx as DependencyObject); i++)
            {
                HighlightText(VisualTreeHelper.GetChild(itx as DependencyObject, i));
            }
        }
    }
