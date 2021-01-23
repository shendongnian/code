    string output = "0AAE0000463130004144430000";
    int checksum = 0;
    
    // You'll need to add error checking that the string only contains [0-9A-F], 
    // is an even number of characters, etc.
    for(int i = 0; i < output.length; i+=2)
    {
       int value = int.Parse(output.SubString(i, 2), NumberStyles.AllowHexSpecifier);
       checksum = (checksum + value) & 0xFF;
    }
    
    checksum = 256 - checksum;
