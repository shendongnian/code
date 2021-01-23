       unsafe public void mf()
       {
          // Null-terminated ASCII characters in an sbyte array 
          sbyte[] sbArr1 = new sbyte[] { 0x41, 0x42, 0x43, 0x00 };
          sbyte* pAsciiUpper = &sbArr1[0];   // CS0212
          // To resolve this error, delete the previous line and 
          // uncomment the following code:
          // fixed (sbyte* pAsciiUpper = sbArr1)
          // {
          //    String szAsciiUpper = new String(pAsciiUpper);
          // }
       }
