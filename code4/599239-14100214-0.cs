    private Bitmap GetSprite(bool anim, int tsIndex, int tileIdx) {
        string prefix;
        System.Drawing.Rectangle cloneRect;
        if (anim) {
            prefix = "A";
            cloneRect = new System.Drawing.Rectangle(BaseObjects.A_AnimSpriteSets[tsIndex].StaticRecs[tileIdx].X, BaseObjects.A_AnimSpriteSets[tsIndex].StaticRecs[tileIdx].Y, BaseObjects.A_AnimSpriteSets[tsIndex].RecWidth, BaseObjects.A_AnimSpriteSets[tsIndex].RecHeight);
        } else {
            prefix = "S";
            cloneRect = new System.Drawing.Rectangle(BaseObjects.A_StaticSpriteSets[tsIndex].StaticRecs[tileIdx].X, BaseObjects.A_StaticSpriteSets[tsIndex].StaticRecs[tileIdx].Y, BaseObjects.A_StaticSpriteSets[tsIndex].RecWidth, BaseObjects.A_StaticSpriteSets[tsIndex].RecHeight);
        }
        try {
            using (Bitmap b = new Bitmap(prefix + tsIndex.ToString() + ".png")) {
                return b.Clone(cloneRect, b.PixelFormat);
            }
        } catch (Exception ex) {
            MessageBox.Show(ex.Message + "\n\n" + "SpriteSet not yet loaded.");
            return null;
        }
    }
