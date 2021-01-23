    public enum WhatBool1AndBool2ActuallyMean
    {
        WhatItMeansWhenBothAreTrue,
        WhatItMeansWhenOnlyBool1IsTrue,
        WhatItMeansWhenOnlyBool2IsTrue,
        WhatItMeansWhenNeitherAreTrue
    }
    
    public WhatBool1AndBool2ActuallyMean GrokMeaning(bool bool1, bool bool2) {...}
    ...
    WhatBool1AndBool2ActuallyMean meaning = GrokMeaning(bool1, bool2);
    switch(meaning)
    {
       case WhatBool1AndBool2ActuallyMean.WhatItMeansWhenBothAreTrue:
           ...
           break;
       case...
    }
