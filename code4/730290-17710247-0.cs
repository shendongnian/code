    byte[] toSend = null;
    int Remaining = ARCHIEVE_BUFFER.Length;
    int Packed = 0;
    while(Remaining > 0){
       toSend = new byte[Remaining >= block ? block : Remaining];
       Buffer.BlockCopy(toSend, 0, ARCHIEVE_BUFFER, Packed, toSend.Length); // not sure about params
       Packed += toSend.Length;
       Remaining -= toSend.Length;
       
       // todo: send here
    }
