    //create a StackPanel
        StackPanel stackPanel1 = new StackPanel();
        stackPanel1.Height = 100;
        stackPanel1.Width = 173;
        stackPanel1.HorizontalAlignment = HorizontalAlignment.Center;
        //put a string array in the listbox, the length of this array is 4
        for (int i=0; i < TaskList.Length; i++)
        {
            //先生成一堆textBlock
            TextBlock txtBlk = new TextBlock();
            txtBlk.Name = "txtBlk" + i.ToString();
            txtBlk.Text = TaskList[i];
            txtBlk.FontSize = 17;
            txtBlk.Width = 173;
            txtBlk.TextWrapping = TextWrapping.NoWrap;
            txtBlk.Foreground = new SolidColorBrush(Colors.White);
            stackPanel1.Children.Add.Add(txtBlk);
        }
