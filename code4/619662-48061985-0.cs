    class MyTreeView : TreeView
    {
        protected override void WndProc(ref Message m)
        {
          if (m.Msg == 0x0203 && this.CheckBoxes)
          {
            var localPos = this.PointToClient(Cursor.Position);
            var hitTestInfo = this.HitTest(localPos);
            if (hitTestInfo.Location == TreeViewHitTestLocations.StateImage)
            {
              m.Msg = 0x0201;
            }
          }
          base.WndProc(ref m);
        }
    }
