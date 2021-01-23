    private void zedGraphControl1_MouseClick(object sender, MouseEventArgs e)
        {
            foreach (var curve in zedGraphControl1.GraphPane.CurveList)
            {
                curve.Color = Color.Black;
            }
            CurveItem nearestItem;
            int nearestPoint;
            zedGraphControl1.GraphPane.FindNearestPoint(e.Location, out nearestItem, out nearestPoint);
            if (nearestItem != null)
            {
                nearestItem.Color = Color.Red;
            }
            zedGraphControl1.Refresh();
        }
