    foreach(integer blacklisted in TwoThousandIntegerList)
    {
        integer index = MillionIntegerList.binarySearch(blacklisted)
        while(MillionIntegerList[index].value == blacklisted){
              //Do your stuff
              ++index;
        } 
    }
