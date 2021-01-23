    public class TimersController : ApiController
    {
       public HttpResponseMessage<TimerDisplay[]> Get()
       {
           return new HttpResponseMessage<TimerDisplay[]>(
               TimerRepository.Get(), // all your .NET logic can be encapsulated here
               new MediaTypeHeaderValue("application/json")
            );
        }
    }
