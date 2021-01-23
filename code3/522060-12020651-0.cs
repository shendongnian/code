    Vector X, Y; //Object is defined. (No memory is allocated.)
    X = new Vector(); //Memory is allocated to Object. //(new is responsible for allocating memory.)
    X.value = 30; //Initialising value field in a vector class.
    Y = X; //Both X and Y points to same memory location. //No memory is created for Y.
    Console.writeline(Y.value); //displays 30, as both points to same memory
    Y.value = 50;
    Console.writeline(X.value); //displays 50.
