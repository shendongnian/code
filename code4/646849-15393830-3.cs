    public class ProfileController {
      public ProfileController() {
           this.service = new ServiceFactory.get<IProfileService>()
      }
    }
