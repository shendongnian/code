    using (var foo = new ObjectWhichMustBeDisposed())
    using (var bar = new OtherObjectWhichMustBeDisposed())
    using (var baz = new OtherObjectWhichMustBeDisposed())
    using (var quux = new OtherObjectWhichMustBeDisposed())
    {
        other code
    }
