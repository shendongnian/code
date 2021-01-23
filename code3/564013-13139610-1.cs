     string jsonString = "";
    var bookCourceObject = BookCourseCollection.ReturnCollection(jsonString);
    foreach (BookCourse bookCourse in bookCourceObject.Collection)
    {
        cs.AssociateCourseBook(bookCourse.netlogon, bookCourse.coursesection, bookCourse.ISBN);
    }
