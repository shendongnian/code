            foreach (int col in Enumerable.Range(0, 20))
            {
                Button b = new Button();
                b.Size = new System.Drawing.Size(30, 30);
                b.Location = new Point(row * 30, col * 30);
                gridPass[row, col] = row.ToString() + " - " + col.ToString();
                b.Tag =  new Point() { Row = row, Column = col }; // <---  Changed.
                b.Text = gridPass[row, col];
                this.Controls.Add(b);
                b.Click += new EventHandler(AttackHandler);
            }
    
    private void AttackHandler(object sender, EventArgs e)
            {
                Button clickedButton = (Button)sender;
                var point = (Point)clickedButton.Tag; // <-- Changed
                theSea.attackLocation(point);  // rewrite attackLocation to accept a point.
            }
