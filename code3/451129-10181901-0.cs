    using System;
    using System.Drawing;
    using System.Drawing.Imaging;
    using System.Windows.Forms;
    
    class FadeControl : UserControl {
    
        public FadeControl() {
            pbox = new PictureBox();
            pbox.BorderStyle = BorderStyle.None;
            pbox.Paint += new PaintEventHandler(pbox_Paint);
            fadeTimer = new Timer();
            fadeTimer.Interval = 15;   // tweakable
            fadeTimer.Tick += new EventHandler(fadeTimer_Tick);
        }
    
        public bool Faded {
            get { return blend < 0.5f; }
        }
        public void FadeIn() {
            stopFade(false);
            createBitmaps();
            startFade(1);
        }
        public void FadeOut(bool disposeWhenDone) {
            stopFade(false);
            createBitmaps();
            disposeOnComplete = disposeWhenDone;
            startFade(-1);
        }
    
        private void createBitmaps() {
            bmpBack = new Bitmap(this.ClientSize.Width, this.ClientSize.Height);
            using (var gr = Graphics.FromImage(bmpBack)) gr.Clear(this.Parent.BackColor);
            bmpFore = new Bitmap(bmpBack.Width, bmpBack.Height);
            this.DrawToBitmap(bmpFore, this.ClientRectangle);
        }
        void fadeTimer_Tick(object sender, EventArgs e) {
            blend += blendDir * 0.02F;   // tweakable
            bool done = false;
            if (blend < 0) { done = true; blend = 0; }
            if (blend > 1) { done = true; blend = 1; }
            if (done) stopFade(true); 
            else pbox.Invalidate();
        }
        void pbox_Paint(object sender, PaintEventArgs e) {
            Rectangle rc = new Rectangle(0, 0, pbox.Width, pbox.Height);
            ColorMatrix cm = new ColorMatrix();
            ImageAttributes ia = new ImageAttributes();
            cm.Matrix33 = blend;
            ia.SetColorMatrix(cm);
            e.Graphics.DrawImage(bmpFore, rc, 0, 0, bmpFore.Width, bmpFore.Height, GraphicsUnit.Pixel, ia);
            cm.Matrix33 = 1F - blend;
            ia.SetColorMatrix(cm);
            e.Graphics.DrawImage(bmpBack, rc, 0, 0, bmpBack.Width, bmpBack.Height, GraphicsUnit.Pixel, ia);
        }
    
        private void stopFade(bool complete) {
            fadeTimer.Enabled = false;
            if (complete) {
               if (!Faded) this.Controls.Remove(pbox);
               else if (disposeOnComplete) this.Dispose();
            }
            if (bmpBack != null) { bmpBack.Dispose(); bmpBack = null; }
            if (bmpFore != null) { bmpFore.Dispose(); bmpFore = null; }
        }
        private void startFade(int dir) {
            this.Controls.Add(pbox);
            this.Controls.SetChildIndex(pbox, 0);
            blendDir = dir;
            fadeTimer.Enabled = true;
            fadeTimer_Tick(this, EventArgs.Empty);
        }
    
        protected override void OnCreateControl() {
            base.OnCreateControl();
            if (!DesignMode) FadeIn();
        }
        protected override void OnResize(EventArgs eventargs) {
            pbox.Size = this.ClientSize;
            base.OnResize(eventargs);
        }
        protected override void Dispose(bool disposing) {
            if (disposing) {
                stopFade(false);
                pbox.Dispose();
                fadeTimer.Dispose();
            }
            base.Dispose(disposing);
        }
    
        private PictureBox pbox;
        private Timer fadeTimer;
        private Bitmap bmpBack, bmpFore;
        private float blend;
        private int blendDir = 1;
        private bool disposeOnComplete;
    }
