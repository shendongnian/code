        private void ClickedButton(object sender, EventArgs e)
        {
            Button s = (Button)sender;
            int x = int.Parse(s.Name.Split()[0]);
            int y = int.Parse(s.Name.Split()[1]);
            if (b[x, y].BackColor == Color.Red || b[x, y].BackColor == Color.Black)
              return;
            var color = cnt == 1 ? Color.Red : Color.Black;
            cnt = 1 - cnt;
            b[x, y].BackColor = color;
              int len = 4;
               
              var directions = new[]
              {
                new {x =  0, y =  1}, 
                new {x =  0, y = -1}, 
                new {x =  1, y =  0},
                new {x = -1, y =  0}, 
                new {x = -1, y = -1},
                new {x =  1, y = -1},
                new {x = -1, y =  1},
                new {x =  1, y =  1}
              };
              b[x, y].BackColor = color;
              foreach (var dir in directions)
              {
                for (var i = 1; i < len; ++i)
                {
                  var xi = x + i * dir.x;
                  var yi = y + i * dir.y;
                  if (xi < 0 || xi >= len || yi < 0 || yi >= len)
                    break;
                  if (b[xi, yi].BackColor != Color.Black && b[xi, yi].BackColor != Color.Red)
                    break;
                  if (b[xi, yi].BackColor == color)
                  {
                    for (var j = 1; j < i; ++j)
                      b[x + j * dir.x, y + j * dir.y].BackColor = color;
                    break;
                  }
                }
              }
        }
