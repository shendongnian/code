            System.Windows.Forms.PictureBox pictureBox = new System.Windows.Forms.PictureBox();
            pictureBox.Width = (int)Math.Sqrt((double)game.Map.grid.Count) * 50; pictureBox.Height = (int)Math.Sqrt((double)game.Map.grid.Count) * 50;
            game.Map.afficher(pictureBox);
            System.Windows.Forms.ScrollableControl sc = new System.Windows.Forms.ScrollableControl();
            sc.Controls.Add(pictureBox);
            sc.AutoScroll = true;
            windowsFormsHost1.Child = sc;
