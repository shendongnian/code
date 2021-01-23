        private byte parityReplace = (byte) '?';
        ...
           int parityFlag = (dcb.Parity == (byte) Parity.None) ? 0 : 1;
           SetDcbFlag(NativeMethods.FPARITY, parityFlag);
           if (parityFlag == 1)
           {
               SetDcbFlag(NativeMethods.FERRORCHAR, (parityReplace != '\0') ? 1 : 0);
               dcb.ErrorChar = parityReplace;
           }
