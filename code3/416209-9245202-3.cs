    viewMock.ExpectAndReturn("get_Original", "Testing ...");
    viewMock.Expect("set_Copy", "Testing ...");
    presenter.OnChanged(viewMock, EventArgs.Empty);
    // here we verify expectations set on mock object; 
    // that Copy setter was called with "Testing ..." value
    viewMock.Verify();
