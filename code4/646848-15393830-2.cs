    public class ProfileController {
      public ProfileController() {
           this.service = resolveFromContainer.Get<IProfileService>();
      }
    }
