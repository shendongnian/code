    WebClient client = new WebClient();       
    System.IO.Stream stream = client.OpenRead(path_of_text _file);
         System.IO.StreamReader str = new StreamReader(stream);
         string Text = str.ReadLine();
       
       while (!Text.EndOfStream)
            {
                string line = Text.ReadLine();
                for (var c = 0; c < line.Length; c++)
                {
                    mazeValues[c, l] = line[c];
                    if (mazeValues[c, l] == '1')
                    {
                        var glass = new Glass();
                        glass.SetValue(Grid.ColumnProperty, c);
                        glass.SetValue(Grid.RowProperty, l);
                        grdMaze.Children.Add(glass);
                        mazeGlasses[c, l] = glass;
                    }
                }
                l++;
            }
     
