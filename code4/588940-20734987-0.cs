        private void button1_Click(object sender, EventArgs e) {
            DrawText("single stroke ttf engraving fonts");
        }
        private void DrawText(string text) {
            using (Graphics g = panel.CreateGraphics())
            using (Font font = new System.Drawing.Font("1CamBam_Stick_1", 50, FontStyle.Regular))
            using (GraphicsPath gp = new GraphicsPath())
            using (StringFormat sf = new StringFormat()) {
                sf.Alignment = StringAlignment.Center;
                sf.LineAlignment = StringAlignment.Center;
                
                gp.AddString(text, font.FontFamily, (int)font.Style, font.Size, panel.ClientRectangle, sf);
                g.Clear(Color.Black);
                g.DrawPath(Pens.Red, gp);
            }
        }
