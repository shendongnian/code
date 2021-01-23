    // Batch is a class that contains the batch byte buffer and the number of bytes valid
    int destinationPos = 0;
    byte[] destination = new byte[<number of bytes in total>];
    foreach (Batch b in batches)
    {
        Array.Copy(b.Bytes, 0, destination, destinationPos, b.ValidLength);
    }
  
