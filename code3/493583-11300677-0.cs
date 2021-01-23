            string ControlIdSuffix = mole < 10 ? "0" : "" + mole.ToString();
            Control[] picBoxes = this.Controls.Find("p" + ControlIdSuffix, true);
            if (picBoxes.Length > 0)
            {
                PictureBox p = picBoxes[0] as PictureBox;
                if (p != null) {
                   if (p.Image == pmiss.Image && MoleHill.Image == pHill.Image)
                      molesMissed++;
                   p.Image = MoleHill.Image;
                }
            }
