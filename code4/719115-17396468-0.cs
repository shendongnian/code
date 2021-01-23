    public async static Task<Bitmap> RollUpDrawingsImage(IElevation elevation)
    {
      int height = 0, width = 800;
      Bitmap completeDrawings = null;
      using (Bitmap elevationDoor = await ShopDrawing.Merger.MergeElevationAndDoorAsync(elevation, RotateFlipType.Rotate90FlipNone))
      using (Bitmap partsList = await (await MaterialsList.Manager.GetMaterialListAsync(elevation)).GetDrawingAsync())
      using (Bitmap optimized = await (await Optimization.Manager.GetOptimizedPartsAsync(elevation)).GetDrawingAsync())
      using (Bitmap cutSheet = await (await CutSheet.Manager.GetCutSheetAsync(elevation)).GetDrawingAsync())
      {
        height = (elevationDoor.Height + optimized.Height + cutSheet.Height + partsList.Height);
        completeDrawings = new Bitmap(width, height + 40);
        using (var dc = Graphics.FromImage(completeDrawings))
        {
          dc.DrawImageUnscaled(elevationDoor, 0, 0);
          dc.DrawImageUnscaled(partsList, 0, elevationDoor.Height + 10);
          dc.DrawImageUnscaled(optimized, 0, (elevationDoor.Height + partsList.Height) + 20);
          dc.DrawImageUnscaled(cutSheet, 0, (elevationDoor.Height + partsList.Height + optimized.Height) + 30);
        }
        return completeDrawings;
      }
    }
