    [Authorize]
    public class MyPageService : IService<MyRequestDTO>
    {
        public object Execute(MyRequestDTO request)
        {
            ...
            return new MyPageViewModel();
        }
    }
