            Foo<Book> fooObj = new Foo<Book>();
            Book aBook = fooObj.oneEmptyElement();
            aBook.name = "Emma";
            Book anotherBook = fooObj.setAttribute("name", "John");
            List<Book> aListOfBooks = fooObj.listOfTwoEmptyElements();
            aListOfBooks[0].name = "Mike";
            aListOfBooks[1].name = "Angelina";
            Console.WriteLine(aBook.name);    //Output Emma
            Console.WriteLine(anotherBook.name);    //Output John
            Console.WriteLine(aListOfBooks[0].name); // Output Mike
            Console.WriteLine(aListOfBooks[1].name);  // Output Angelina
