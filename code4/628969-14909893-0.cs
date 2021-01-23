    Dictionary<string, ulong> ColumnsInNumber = new Dictionary<string, ulong>();
    string Alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
    ulong SpecialNumber = 0;
    
    foreach (char FirstChar in Alphabet)
       ColumnsInNumber.Add(FirstChar.ToString(), SpecialNumber++);
    
    foreach (char FirstChar in Alphabet)
       foreach (char SecondChar in Alphabet)
          ColumnsInNumber.Add(string.Format("{0}{1}", FirstChar, SecondChar), SpecialNumber++);
    
    foreach (char FirstChar in Alphabet)
       foreach (char SecondChar in Alphabet)
          foreach (char ThirdChar in Alphabet)
              ColumnsInNumber.Add(string.Format("{0}{1}{2}", FirstChar, SecondChar, ThirdChar), SpecialNumber++);
