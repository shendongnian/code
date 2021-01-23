        List<Point> plist = new List<Point>();
        private void webBrowser1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.C:                   
                    plist.Add(webBrowser1.PointToClient(Cursor.Position));                    
                    break;
                default:
                    break;
            }
        }
