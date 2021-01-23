    for (int j = 1; j <= A.Length - B.Length; j++)
    {
        siga = (siga + Q - pow * (ulong)A[j - 1] % Q) % Q;
        siga = (siga * D + (ulong)A[j + B.Length - 1]) % Q;
        if (siga == sigb)
        {
            if (A.Substring(j, B.Length) == B)
            {
                Console.WriteLine(string.Format("{0}>>{1}<<{2}", A.Substring(0, j),
                                                                    A.Substring(j, B.Length),
                                                                    A.Substring(j + B.Length)));
                return;
            }
        }
    }
