    if (!(flatestgames == null || flatestgames.Length < 1))
            {
                i = 0;
                LinkLabel[] flg = new LinkLabel[10];
                foreach (string s in flatestgames)
                {
                    flg[i] = new LinkLabel();
                    flg[i].Text = s;
                    flg[i].Links.Add(0, s.Length, flatestlinks[i]);
                    Point p = new Point(43, 200 + 23 * i);
                    flg[i].Location = p;
                    flg[i].Visible = true;
                    flg[i].Show();
                    this.Controls.Add(flg[i]);
                    i++;
                }
            }
