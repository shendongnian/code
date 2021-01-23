    Dictionary<Int32, Double> dictOil1 = new Dictionary<Int32, Double();
    Dictionary<Int32, Double> dictOil2 = new Dictionary<Int32, Double();
    //If seqNum and netOil _really are_ strings...
    Int32 seq, seq2;
    Double oil, oil2;
    if (Int32.TryParse(seqNum, out seq) && Double.TryParse(netOil, out oil))
        dictOil1.Add(seq, oil);
    if (Int32.TryParse(seqNum2, out seq2) && Double.TryParse(netOil2, out oil2))
        dictOil2.Add(seq2, oil2);
