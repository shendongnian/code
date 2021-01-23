    AnswerObject answerObject;
    ICollection <ISomeObject> collection;
    int number;
    
    IClass iClassMock = MockRepository.GenerateMock<IClass>();
    iClassMock
      .Stub(x => x.FunctionGetCollection(
        Arg<ICollection <ISomeObject>>.Ref(Is.Anything, collection).Dummy,
        Arg<int>.Ref(Is.Anything(), number).Dummy);
      .Return(answerObject);
