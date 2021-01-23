        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            SolidBrush laczniki = new SolidBrush(Color.Gray);
            Pen lacznikipen = new Pen(Color.Gray, 5);
            SolidBrush funkcja = new SolidBrush(Color.Green);
            Pen funkcjapen = new Pen(Color.Green, 5);
            SolidBrush zdarzenie = new SolidBrush(Color.Red);
            Pen zdarzeniepen = new Pen(Color.Red, 5);
            SolidBrush strzalka = new SolidBrush(Color.Black);
            Graphics rysujem = panel1.CreateGraphics();
            foreach (KeyValuePair<int, baza> luskanie in Form1.naszalista)
            {
                baza bz = luskanie.Value;
                if (bz.rodzaj == "funkcja")
                {
                    rysujem.FillEllipse(funkcja, 20, 20, 40, 20);
                    rysujem.DrawString(funkcjazdarzenie.nazwa, new Font("Segoe", 9), Brushes.Green, 20, 20);
                }
                else if (bz.rodzaj == "zdarzenie")
                {
                    rysujem.FillPie(zdarzenie, 20, 20, 20, 20, 20, 20);
                }
                else if (bz.rodzaj == "XOR")
                {
                }
                else if (bz.rodzaj == "OR")
                {
                }
                else if (bz.rodzaj == "AND")
                {
                }
            }
        }
