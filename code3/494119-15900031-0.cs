        public void OnDrawUndo(object sender, RoutedEventArgs e)
        {
            try
            {
                BackupInkStrokeCollection.Push(CurrentInkStrokeCollection.Pop());
                renderer.Clear();
                renderer.AddInk(CurrentInkStrokeCollection);
               
                //inkManager.GetStrokes()[inkManager.GetStrokes().Count - 1].Selected = true;
                InkStroke SelectedStroke = inkManager.GetStrokes()[inkManager.GetStrokes().Count - 1];
                SelectedStroke.Selected = true;
                var MyInkManager = new InkManager();
                MyInkManager.AddStroke(SelectedStroke.Clone());
                MyInkManagers.Add(MyInkManager);
                inkManager.DeleteSelected();
            }
            catch (Exception ee)
            {
                if (ee.Message == "Stack empty.")
                    return;
                else
                    new Windows.UI.Popups.MessageDialog(ee.ToString()).ShowAsync();
            }
        }
