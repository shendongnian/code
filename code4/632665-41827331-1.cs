    Foo<Book> myTestClass = new Foo<Book>();
    Book aBook = myTestClass.oneEmptyElement();
    aBook.id = 10;
    List<Book> aListOfBooks = myTestClass.listOfTwoEmptyElements();
    aListOfBooks[0].id = 100;
    aListOfBooks[1].id = 101;
    Console.WriteLine(aBooks.id);    //Output 10
    Console.WriteLine(aListOfBooks[0].id ); // Output 100
    Console.WriteLine(aListOfBooks[1].id);  // Output 101
