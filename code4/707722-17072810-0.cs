    public interface IJsonReader
    {
       dynamic SqueezeJson(Stream stream);
    }
    
    public class JsonReader : IJsonReader
    {
       //implement SqeezeJson method
    }
    
    public class MyController
    {
       private readonly IJsonReader _jsonReader;
       public MyController(IJsonReader jsonReader)
       {
          _jsonReader = jsonReader;
       }
    
       public ActionResult Create()
       {
           var data = _jsonReader.SqeezeJson(Context.Request.InputStream);
           //... do wahtever needed
       }
    }
    
    // ... and the tests
    
    [Test]
    public void SqueezeJsonTest()
    {
       //test that the reader works as expected
    }
    
    public void ControllerTest()
    {
       //arrange
       var requestStream = Mock.Of<Stream>();
       var request = Mock.Of<HttpRequestBase>( r => 
           r.InputStream == requestStream &&
           r.Url == "http://whatever");
       var context = Mock.Of<HttpRequestBase>(c=>c.Request == request);
    
       dynamic sqeezedData = new ExpandoObject(); // populate with the expected data from reader
       var mockReader = new Mock<IJsonReader>();
       mockReader.Setup(r=>r.SqeezeJson(requestStream)).Returns(sqeezedData); 
    
       var controller = new MyController();
       controller.Context = context;
    
       //act
       var result = controller.Create();
    
       //assert
       //whatever is needed to verify that the controller processed the sueezed data
    }
