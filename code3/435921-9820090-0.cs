        private DateTime firstClick = DateTime.Now;
        private void axDrawingControl1_MouseUpEvent(object sender, AxMicrosoft.Office.Interop.VisOcx.EVisOcx_MouseUpEvent e)
        {
            if (DateTime.Now < firstClick.AddMilliseconds(SystemInformation.DoubleClickTime))
            {
                ShapeDoubleClick(sender, e);
            }
            firstClick = DateTime.Now;
        }
