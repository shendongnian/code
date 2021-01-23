        private void button2_Click(object sender, EventArgs e)
        {
            var GoldIron = new List<Point>(
            new Point[]{
            new Point(16,23),new Point(16,28),new Point(19,44),new Point(21,29),
            new Point(23,16),new Point(24,82),new Point(27,85),new Point(31,63),
            new Point(31,78),new Point(32,65),new Point(41,23),new Point(43,79),
            new Point(44,76),new Point(45,23),new Point(47,16),new Point(50,15),
            new Point(50,37),new Point(52,28),new Point(52,58),new Point(52,71),
            new Point(61,39),new Point(61,75),new Point(63,59),new Point(68,25),
            new Point(68,61),new Point(70,24),new Point(71,75),new Point(74,78),
            new Point(77,59),new Point(82,27)}
            );
            listBox1.DataSource = GoldIron;
            //Split into 2 lists based on the gold amount
            var Left = new List<Point>();
            var Right = new List<Point>();
            var SumGold = GoldIron.Sum(P => P.X);
            var SumIron = GoldIron.Sum(P => P.Y);
            label2.Text = SumGold.ToString();
            label1.Text = SumIron.ToString();
            var LeftGold = 0;
            Int32 i = 0;
            while (LeftGold < SumGold / 2)
            {
                LeftGold += GoldIron[i].X;
                Left.Add(GoldIron[i++]);
            }
            while (i < GoldIron.Count)
            {
                Right.Add(GoldIron[i++]);
            }
            Int32 LIndex = 0;
            //Start Algorithm
            Int32 LeftIron = Left.Sum(P => P.Y);
            Int32 RightIron = Right.Sum(P => P.Y);
            while (LeftIron - RightIron > 50 || RightIron - LeftIron > 50)
            {
                if (LeftIron < RightIron)
                {
                    List<Point> TempList = Left;
                    Left = Right;
                    Right = TempList;
                    LIndex = 0;
                }
                Int32 SmallestRight = Right[LIndex].X;
                LeftGold = 0;
                i = 0;
                while (LeftGold < SmallestRight)
                {
                    LeftGold += Right[i++].X;
                }
                Point Temp = Right[LIndex];
                Right.RemoveAt(LIndex);
                Right.AddRange(Left.Take(i));
                Left.RemoveRange(0, i);
                Left.Add(Temp);
                LIndex += i;
                //Sort
                Left.Sort(CompareGold);
                Right.Sort(CompareGold);
                LeftIron = Left.Sum(P => P.Y);
                RightIron = Right.Sum(P => P.Y);
            }
            listBox2.DataSource = Left;
            SumGold = Left.Sum(P => P.X);
            SumIron = Left.Sum(P => P.Y);
            label4.Text = SumGold.ToString();
            label3.Text = SumIron.ToString();
            listBox3.DataSource = Right;
            SumGold = Right.Sum(P => P.X);
            SumIron = Right.Sum(P => P.Y);
            label6.Text = SumGold.ToString();
            label5.Text = SumIron.ToString();
        }
