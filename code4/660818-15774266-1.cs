    foreach (DataRow row in table.Rows)
    {
        var newMaskedSSN = DecryptSSN(row["EncryptedSSN"].ToString()); 
        if (newMaskedSSN.Length > 4)
        {
            Console.WriteLine(
                string.Concat(
                   "".PadLeft(9, '*'), 
            newMaskedSSN.Substring(newMaskedSSN.Length - 4)));
            row["SSN"] = newMaskedSSN; 
            row.AcceptChanges();
        }
    }
