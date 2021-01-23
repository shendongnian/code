    String WhatDayItIs = DayOfWeek.Monday.ToString();     
    
    DayOfWeek WhatDayItIsDOW;
    
    if (Enum.IsDefined(typeof(DayOfWeek), WhatDayItIs)) 
            WhatDayItIsDOW = (DayOfWeek)Enum.Parse(typeof(DayOfWeek), WhatDayItIs);
    
     
