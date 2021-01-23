    int carry = 0;
    for (int i = 0; i < input.Count; i++)
    {
        int sum = carry + input[i]; // add previous carry
        output.Add(sum % 10);       // store the "units"
        carry = sum / 10;           // carry the "tens"
    }
    while (carry > 0)               // anything left carried?
    {
        output.Add(carry % 10);     // store the "units"
        carry = carry / 10;         // carry the "tens"
    }
