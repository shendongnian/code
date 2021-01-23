    //WorksheetMerge is a custom method (see below)
    WorksheetMerge((Excel.Worksheet)liVAD_plus.Worksheets["Media Packs"], (Excel.Worksheet)liVAD_plus.Worksheets["Express Program"]);
    //
    static public void WorksheetMerge(Excel.Worksheet origine, Excel.Worksheet destinazione)
        {
            Excel.Range rngOrigine = origine.UsedRange;
            rngOrigine.Copy(Type.Missing);
            Excel.Range rngDestinazioneLastCell = destinazione.UsedRange.Offset[destinazione.UsedRange.Rows.Count, 0];
            rngDestinazioneLastCell.PasteSpecial(Excel.XlPasteType.xlPasteAll, Excel.XlPasteSpecialOperation.xlPasteSpecialOperationNone, false, false);
        }
