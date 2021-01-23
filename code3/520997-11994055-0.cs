    class MyAwesomeController : ApiController {
        public HttpResponseMessage ByYear(int year) {
            MyAwesomeViewModel[] models = Rep.GetByYear(year);
            return new HttpResponseMessage(statusGoesHere) { Content = GetUIContent(models) };
        }
    }
    
    class UIContent : HttpContent {
       ...
    }
