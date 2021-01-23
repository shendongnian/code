        for (int i = 0; i < B.Length; i++)
        {
            siga = (siga * D + (ulong)A[i]) % Q;
            sigb = (sigb * D + (ulong)B[i]) % Q;
        }
        if (siga == sigb)
        {
            Console.WriteLine(string.Format(">>{0}<<{1}", A.Substring(0, B.Length), A.Substring(B.Length)));
            return;
        }
