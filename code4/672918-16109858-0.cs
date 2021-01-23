    // b1 is now 5 bytes
    byte[] b1 = Get5BytesFromSomewhere();
    // creating a 6-byte array
    byte[] temp = new byte[6];
    // copying bytes 0-4 from b1 to temp
    Array.copy(b1, 0, temp, 0, 5);
    // adding a 6th byte
    temp[5] = (byte)11;
    // reassigning that temp array back to the b1 variable
    b1 = temp;
