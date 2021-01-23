    iClassMock
      .Stub(x => x.FunctionGetCollection(
        ref Arg<ICollection <ISomeObject>>.Ref(Is.Anything(), null).Dummy,
        ref Arg<int>.Ref(Is.Anything(), 0).Dummy);
      .WhennCalled(call =>
      {
        // reset the ref arguments to what had been passed to the mock
        // not sure if it also works with the int
        call.Arguments[0] = call.Arguments[0];
        call.Arguments[1] = call.Arguments[1];
      })
      .Return(answerObject);
