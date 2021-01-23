    for (int i = 1; i < visits.Count(); i++)
    {
       Visit visit = visits[i];
       decimal? charges = visit.TotalCharges();
       decimal? payments = visit.TotalPayments();
       decimal? totAdj = visit.PaymentAdjustments.Where(x => x.nrv_cd.Trim() == "C01").Sum(s => s.pmt_pst_at);
       decimal? actbalance = charges - (payments + totAdj);
       CareGiver attending = visit.AttendingPhysicianCareGiver();
       workbook.AddCell(r, cell++, visit.Person.DisplayName());
       workbook.AddCell(r, cell++, visit.vst_ext_id.Trim());
       workbook.AddCell(r, cell++, visit.LosFormatted());
       workbook.AddCell(r, cell++, visit.CodeDetail.cod_dtl_ds); 
       workbook.AddCell(r, cell++, visit.CodeDetail.cod_dtl_ext_id.Trim());
       workbook.AddCell(r, cell++, charges);
       workbook.AddCell(r, cell++, payments);
       workbook.AddCell(r, cell++, totAdj);
       workbook.AddCell(r, cell++, actbalance);
       r++;
    }
    //new code
    workbook.ChangeWorksheet(2);
    for (int i = 1; i < visits.Count(); i++)
    {
        Visit visit = visits[i];
        //when moving to this nested loop, it picks up all charge codes for that visit
        foreach (Charge c in visit.Charges)
        {
          workbook.AddCell(j, 0, visit.vst_ext_id.Trim());
          workbook.AddCell(j, 1, c.ChargeDefinition.chg_cod_ext_id.Trim());
          j++;
        }
        //when moving to this nested loop, it picks up all adjustment codes for that visit
        foreach (PaymentAdjustment pa in visit.PaymentAdjustments)
        {
          workbook.AddCell(j, 0, visit.vst_ext_id.Trim());
          workbook.AddCell(j, 1, pa.ChargeDefinition.chg_cod_ext_id.Trim());
          j++;
        }
    }
