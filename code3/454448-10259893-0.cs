     Point[] p = new Point[6];
            string log = "";
            Button[] btn = new Button[6];
            for (int i = 0; i < btn.GetLength(0); i++)
            {
                btn[i] = new Button();
                btn[i].Height = 65;
                btn[i].Width = 80;
                p[i] = new Point();
                p[i].X = i * 83;
                p[i].Y = 0;
                log += p.ToString() + "\n";
                btn[i].PointToClient(p[i]);
                btn[i].Show();
            }
            FlowLayoutPanel pan = new FlowLayoutPanel();
            pan.Width=500;//width of all buttons
            pan.Height = 100;
            pan.Controls.AddRange(btn);
            panel1.Controls.Add(pan);
