    namespace ConsoleApplication5
    {
        public interface IFacebookHelper { dynamic Get(string p); }
        class Program
        {
            static void Main(string[] args)
            {
                Mock<IFacebookHelper> mockFbHelp = new Mock<IFacebookHelper>();
                mockFbHelp.Setup(x => x.Get("me")).Returns(new { email = "test@test.com", id = "9999" });
                dynamic result = mockFbHelp.Object.Get("me");
                int facebookId = int.Parse(result.id);
                string email = result.email;
            }
        }
    }
