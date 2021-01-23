    var strInput = "1Dept Neurosci, The Univ. of New Mexico, ALBUQUERQUE, NM; 2Mol. and Human Genet., Baylor Col. of Med., Houston,, TX; 3Psychiatry, Univ. of Texas Southwestern Med. Ctr., Dallas, TX; 4Clin. Genet., Erasmus Univ. Med. Ctr., Rotterdam, Netherlands; 5Human Genet., Emory Univ., Atlanta, GA";
    var adresses = new List<string>();
    foreach (Match match in Regex.Matches(strInput, @"\d+[^\d]+"))
    {
        adresses.Add(match.Value);
    }
