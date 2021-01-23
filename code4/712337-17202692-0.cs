    public class TestService : Service {
        public object Delete(TestRequest request){
            return request.id;
        }
    }
