        while (i < n && j < m)
        {
            if (A[i] < B[j])
            {
                C[k] = A[i];
                i++;
            }
            else
            {
                C[k] = B[j];
                j++;
            }
            k++;
        }
        if (i == n)
        {
            for (int b = j; b < B.Length; b++)
            {
                C[k++] = B[b];
            }
        }
        else
        {
            for (int a = i; a < A.Length; a++)
            {
                C[k++] = A[a];
            }
        }
