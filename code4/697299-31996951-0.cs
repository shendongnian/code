    using acColor = Autodesk.AutoCAD.Colors;
    using acWindows = Autodesk.AutoCAD.Windows;
    //...
        public acColor.Color GetAutoCADColor()
        {
            acWindows.ColorDialog colorDialog = new acWindows.ColorDialog();
            DialogResult dialogResult = new DialogResult();
            dialogResult = colorDialog.ShowDialog();
            switch (dialogResult)
            {
                case DialogResult.OK:
                    return colorDialog.Color;
                case DialogResult.Cancel:
                    return Color.Empty.ConvertToAutoCADColor();
                default:
                    return Color.Empty.ConvertToAutoCADColor();
            }
        }
