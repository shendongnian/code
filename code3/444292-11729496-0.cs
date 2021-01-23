    Shape waterMarkRect = null;
    try { 
        waterMarkRect = page.Shapes["DraftText"];
    }
    catch (Exception){
    }
    if (waterMarkRect == null)
    {
       waterMarkRect = page.DrawRectangle(0, 0, 50, 15);
       waterMarkRect.Name = "DraftText";
       waterMarkRect.NameU = waterMarkRect.Name;
       waterMarkRect.Text = "INCONSISTANT";
       Layer wMarkLayer = page.Layers["WMark"] ?? page.Layers.Add("WMark");
       wMarkLayer.Add(waterMarkRect, 0);
    }
