           LayoutView View = (sender as LayoutView);
            var hi = View.CalcHitInfo(e.Location);
            if (hi.HitTest == LayoutViewHitTest.LayoutItem && hi.LayoutItem is DevExpress.XtraLayout.LayoutControlGroup)
            {
                var Border = (hi.LayoutItem.ViewInfo.BorderInfo as DevExpress.Utils.Drawing.GroupObjectInfoArgs);
                if (Border.CaptionBounds.Contains(e.Location))
                {
                    MessageBox.Show("Hit Group: " + Border.Caption);
                    return;
                }
            }
            MessageBox.Show("Missed!");
