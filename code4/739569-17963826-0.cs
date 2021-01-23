    var results = ArrayFunc.QueryResult.SelectMany(l1 => ArrayFunc.QueryResult1, (l1, l2) => new DRFGAModifiedRecord
      {
            RecordDocID = l1.FGACol1;
            DRNo = l1.FGACol2;
            DDNum = l1.FGACol3;
            LineNumber = l1.FGACol4;
            Itemnmbr = l2.updItemCode;
            Itemdesc = l2.updItemDesc;
            Pallet = l2.updPallets;
            BagsNo = l2.updBagsNo;
            TotalLoaded = l2.updTotalKgs;
            PostStat = l2.updPostStat;
            ProdCode = l2.updProdcode;
            VariantCode = l2.updVariantCode;
            DateModify = DateTime.Now.ToShortDateString();
            TimeModify = DateTime.Now.ToShortTimeString();
            UserModify = "Mik";//GlobalvarClass.LogUser;
            ReasonModify = GlobalvarClass.GetModReasOnDR;
            FileType = "New";
      }).ToList();
    foreach (row in results)
    {
      saveREC(row);
      gfunc.MsgBox("Saved", 1);
    }
