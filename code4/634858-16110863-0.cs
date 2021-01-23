                private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                spaceKeyDown = true;
            }
            if (e.KeyCode == Keys.Up)
            {
                spaceKeyUp = true;
            }
            if (e.KeyCode == Keys.W)
            {
                spaceKeyW = true;
            }
            if (e.KeyCode == Keys.S)
            {
                spaceKeyS = true;
            }
            if (direction == 0)
            {
                if (e.KeyCode == Keys.Space)
                {
                    Random rand = new Random();
                    direction = rand.Next(1, 5);
                }
            }
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Down)
            {
                spaceKeyDown = false;
            }
            if (e.KeyCode == Keys.Up)
            {
                spaceKeyUp = false;
            }
            if (e.KeyCode == Keys.W)
            {
                spaceKeyW = false;
            }
            if (e.KeyCode == Keys.S)
            {
                spaceKeyS = false;
            }
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (spaceKeyDown == true)
            {
                if (p2y < picPicture.Height - Paddle2.Height)
                    p2y += 15;
            }
            if (spaceKeyUp == true)
            {
                if (p2y > 0)
                    p2y -= 15;
            }
            if (spaceKeyS == true)
            {
                if (p1y < picPicture.Height - Paddle1.Height)
                    p1y += 15;
            }
            if (spaceKeyW == true)
            {
                if (p1y > 0)
                    p1y -= 15;
            }
        }
