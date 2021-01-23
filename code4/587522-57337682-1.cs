public int solution(int[] A)
 {
    // write your code in C# 6.0 with .NET 4.5 (Mono)
    Array.Sort(A);
    var max = A.Max();
    if(max < 0)
        return 1;
    else
        for (int i = 1; i < max; i++)
        {
            if(!A.Contains(i)) {
                return i;
            }
        }
    return max + 1;
}
