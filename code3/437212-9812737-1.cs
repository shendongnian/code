    int carry = 0;
    IP4 += totalIPs;
    carry = IP4 / 254;
    IP4 = IP4 % 254;
    if(carry>0) // Need to spill over IP3
    {
       IP3 += carry;
       carry = IP3 / 254;
       IP3 = IP3 % 254;
       if(carry > 0)  // Spill over to IP2
       {
           IP2 += carry;
           carry = IP2 / 254;
           IP2 = IP2 % 254;
           IP1 += carry;
           IP1 %= 254;    // No spill-over here
       }
    }
