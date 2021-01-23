    AnswerObject answerObject;
    ICollection <ISomeObject> collection;
    int number;
    
    IClass iClassMock = MockRepository.GenerateMock<IClass>();
    iClassMock
      .Stub(x => x.FunctionGetCollection(
        ref Arg<ICollection <ISomeObject>>.Ref(Is.Anything(), collection).Dummy,
        ref Arg<int>.Ref(Is.Anything(), number).Dummy);
      .Return(answerObject);
