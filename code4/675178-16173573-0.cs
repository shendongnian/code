    IEnrollment enrollment1 = new Enrollment();
    IEnrollment enrollment2 = new Enrollment();
    Enrollments enrollments = new Enrollments(enrollment1, enrollment2);
    IEnumerator<IEnrollment> enumerator = enrollment.GetEnumerator();
    enumerator.MoveNext();
    Assert.That(enumerator.Current, Is.EqualTo(enrollment1));
    enumerator.MoveNext();
    Assert.That(enumerator.Current, Is.EqualTo(enrollment2));
    enumerator.Reset(); // Move back to the beginning of the list
    enumerator.MoveNext();
    Assert.That(enumerator.Current, Is.EqualTo(enrollment1));
    enumerator.MoveNext();
    Assert.That(enumerator.Current, Is.EqualTo(enrollment2));
