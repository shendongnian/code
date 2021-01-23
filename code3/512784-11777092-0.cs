    using System;
    using System.Drawing;
    using System.Collections.Generic;
    using System.Windows.Forms;
    
    class BlinkingButtonRenderer : ToolStripProfessionalRenderer {
        public BlinkingButtonRenderer(ToolStrip strip) {
            this.strip = strip;
            this.strip.Renderer = this;
            this.strip.Disposed += new EventHandler(strip_Disposed);
            this.blinkTimer = new Timer { Interval = 500 };
            this.blinkTimer.Tick += delegate { blink = !blink; strip.Invalidate(); };
        }
    
        public void BlinkButton(ToolStripButton button, bool enable) {
            if (!enable) blinkButtons.Remove(button);
            else blinkButtons.Add(button);
            blinkTimer.Enabled = blinkButtons.Count > 0;
            strip.Invalidate();
        }
    
        protected override void OnRenderButtonBackground(ToolStripItemRenderEventArgs e) {
            var btn = e.Item as ToolStripButton;
            if (blink && btn != null && blinkButtons.Contains(btn)) {
                Rectangle bounds = new Rectangle(Point.Empty, e.Item.Size);
                e.Graphics.FillRectangle(Brushes.Black, bounds);
            }
            else base.OnRenderButtonBackground(e);
        }
    
        private void strip_Disposed(object sender, EventArgs e) {
            blinkTimer.Dispose();
        }
    
        private List<ToolStripItem> blinkButtons = new List<ToolStripItem>();
        private bool blink;
        private Timer blinkTimer;
        private ToolStrip strip;
    }
