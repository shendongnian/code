    public class HomeController : BaseController
    {
     public CaptchaImageResult ShowCaptchaImage()
        {
            return new CaptchaImageResult();
        }
    }
