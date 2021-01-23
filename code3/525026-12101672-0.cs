    float checkNumber = 8.1234567;
    String number = new String( checkNumber ); // If memory serves, this is completely valid
    int position = number.indexOf( "." ); // This could be number.search("."), I don't recall the exact method name off the top of my head
    if( position >= 0 ){ // Assuming search or index of gives a 0 based index and returns -1 if the substring is not found
        number = number.substring( position ); // Assuming this is the correct method name to retrieve a substring.
        int decimal = new Int( number ); // Again, if memory serves this is completely valid
    }
