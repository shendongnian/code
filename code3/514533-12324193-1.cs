private void tabControl1_DrawItem(object sender, System.Windows.Forms.DrawItemEventArgs e)
{
      SolidBrush fillbrush= new SolidBrush(Color.Red);
      //draw rectangle behind the tabs
      Rectangle lasttabrect = tabControl1.GetTabRect(tabControl1.TabPages.Count - 1);
      Rectangle background = new Rectangle();
      background.Location = new Point(lasttabrect.Right, 0);
      //pad the rectangle to cover the 1 pixel line between the top of the tabpage and the start of the tabs
      background.Size = new Size(tabControl1.Right - background.Left, lasttabrect.Height+1);
      e.Graphics.FillRectangle(fillBrush, background);
    }
'This answer is much correct than prior one. But the tabCtrl is not defined. It has to be tabControl1 control.
