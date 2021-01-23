    // put this at the top of your source file
    using System.Linq;
    // put this where you calculate the maxima
    for(int i = 0; i < array2.GetLength(0); ++i)
    for(int j = 0; j < array2.GetLength(1); ++j)
    {
        array2[i, j] = Convert.ToInt32(li.Max(x => x.GetValue(i, j)));
    }
