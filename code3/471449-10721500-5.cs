    foreach(integer blacklisted in TwoThousandIntegerList)
    {
        integer index = MillionIntegerList.binarySearch(blacklisted)
        //Find the index of the first occurrence of blacklisted value
        while(index > 0 && MillionIntegerList[index - 1].value == blacklisted){
              --index;
        }
        while(MillionIntegerList[index].value == blacklisted){
              //Do your stuff
              ++index;
        } 
    }
