           int spacing = 75;
            int columns = 6;
            //Use your variable above to create the array
            Label[][] map = new Label[columns][];
            
            for (int i = 0; i < columns; i++) {
                //Create a new sub array
                map[i] = new Label[columns];
                for (int j = 0; j < columns; j++) {
                    map[i][j] = new Label();
                    map[i][j].AutoSize = true;
                    map[i][j].BackColor = Color.Black;
                    map[i][j].Location = new Point(i * spacing, j * spacing);
                    map[i][j].Name = "map" + i.ToString() + "," + j.ToString();
                    map[i][j].Width = spacing;
                    map[i][j].Height = spacing;
                    map[i][j].TabIndex = 0;
                    map[i][j].Text = "test" + i.ToString() + j.ToString();
                }
                //Add the range to the panel
                panel1.Controls.AddRange(map[i]);
            }
