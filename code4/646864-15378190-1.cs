    Student accessibleVariable; // initialize it if required.
    foreach (Student newSortedStudent in studentWithData)
    {
        accessibleVariable= newSortedStudent.Fee.OrderBy......ToArray();
    }
    // access as usual
    foreach(Student studentData in **accessibleVariable**)
    {
        ....
    }
