     foreach (PanelView panel in pv)
        {
            path = Request.PhysicalPath.Substring(0, Request.PhysicalPath.LastIndexOf('\\') + 1) + subPath + "\\" + GetRaumImageName(panel.Title);
            bitMap = new Bitmap(path + ".bmp");
            b0 = BmpToMonochromConverter.CopyToBpp(bitMap, 1);
           // bounce.updateInterface.UpdateProductImage(b0, panel.Panel.PRODUCT_ID, "", ref update_Handle);
            bitMap.Dispose();
        }
