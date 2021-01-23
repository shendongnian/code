    int[] vowels = {Letters.A, Letters.E, Letters.I, Letters.O, Letters.U};
    IEnumerable<int> consonant = Enum.GetValues(typeof(Letters)).Except(vowels);
    foreach (int consonant in consonants)
    {
        // Do something with each consonant
    }
