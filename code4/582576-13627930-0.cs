    public static IList<MedicalRecord> UpdateServicePrice(
        IList<MedicalRecord> mListMedicalRecord,
        IList<ServicePrice> listAllServicePrice)
    {
        foreach (var j in mListMedicalRecord.GroupJoin(listAllServicePrice,
            mr => mr.MedicalRecordID,
            sp => sp.MedicalRecordID,
            (mr, sps) => new { Record = mr, Prices = sps }))
        {
            j.Record.mListServicePrice = j.Prices.ToList();
        }
        return mListMedicalRecord;
    }
