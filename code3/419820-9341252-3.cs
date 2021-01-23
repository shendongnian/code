      private void toolStripButton1_Click(object sender, EventArgs e)
      {
         this.toolStripButton1.Image.Dispose();
         System.ComponentModel.ComponentResourceManager resources =
            new System.ComponentModel.ComponentResourceManager(typeof(Form1));
         this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
         ((Bitmap)toolStripButton1.Image).DrawText("C", Font, SystemBrushes.ControlText,
            new RectangleF(new PointF(0, 0), toolStripButton1.Image.Size));
      }
