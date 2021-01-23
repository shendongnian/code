    //In FormLoad
    Form1.MouseDown += FireBullet_MouseDown;
    pnlGame.MouseDown += FireBullet_MouseDown;
    private void FireBullet_MouseDown(object sender, MouseEventArgs e)
    {
            if (Bullet == 0)
            {
                tmrShoot.Enabled = false;
                return; //leaves the method and followup code doesnt run
            }
    
            if (e.Button == MouseButtons.Left)
            {
                bullets.Add(new Bullet(robot.RobotRec));
                Bullet -= 1;// lose a life
                lblBullet.Text = Bullet.ToString();// display number of lives
            }
    }
