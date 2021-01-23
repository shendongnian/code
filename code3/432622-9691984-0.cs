    public interface IMapper
    {
        ClassB MapMe(ClassA entity);
        ClassA MapMe(ClassB entity);
    }
    public class BigClass : IMapper
    [Test]
    public void MapperTest()
    {
        IMapper mapperMock = MockRepository.GenerateMock<IMapper>();
        mapperMock.Expect(x => x.MapMe(Arg<ClassA>.Is.Anything))
                    .WhenCalled((mi) =>
                            {
                                Debug.WriteLine("MapMe - ClassA parameter");
                            })
                    .Return(null /*TODO: return correct instance*/);
        mapperMock.Expect(x => x.MapMe(Arg<ClassB>.Is.Anything))
                    .WhenCalled((mi) =>
                            {
                                Debug.WriteLine("MapMe - ClassB parameter");
                            })
                    .Return(null /*TODO: return correct instance*/);
                
        var resultB = mapperMock.MapMe(new ClassA());
        var resultA = mapperMock.MapMe(new ClassB());
    
       // TODO: Asserts
    }
