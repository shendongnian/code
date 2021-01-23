    bool pretendA20 = false;
    
    if (a < 10)
    {
        switch (b)
        {
            case 0:
                //Actions for A<10, B=0, using local variables
                break;
            case 1:
                double c = someFunction(a, b);  //In real code involves calculations based on a and b
                if(c > 10.0)
                    //goto lbl_proc_20;   
                    pretendA20 = true;
                    //Actions for A<10, B=1, using local variables
                break;
            default:
                //Actions for A<10, B=Other, using local variables
                break;
        }
    }
    else if (a < 20 || pretendA20)
    {
    //lbl_proc_20:
        switch(b)
        {
