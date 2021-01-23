    private Bitmap GetSprite(bool anim, int tsIndex, int tileIdx) {
        string prefix;
        System.Drawing.Rectangle cloneRect;
        SpriteSet set;
        if (anim) {
            prefix = "A";
            set = BaseObjects.A_AnimSpriteSets[tsIndex];
        } else {
            prefix = "S";
            set = BaseObjects.A_StaticSpriteSets[tsIndex];
        }
        cloneRect = new System.Drawing.Rectangle(set.StaticRecs[tileIdx].X, set.StaticRecs[tileIdx].Y, set.RecWidth, set.RecHeight);
        try {
            using (Bitmap b = new Bitmap(prefix + tsIndex.ToString() + ".png")) {
                return b.Clone(cloneRect, b.PixelFormat);
            }
        } catch (Exception ex) {
            MessageBox.Show("Error: " + ex.Message + "\n\nCause: " + "SpriteSet not yet loaded.");
            return null;
        }
    }
