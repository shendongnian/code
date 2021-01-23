    public abstract class BaseDto {
        string property1;
        ...
        string propertyN;
    } 
    public class PublicDto : BaseDto {
          Guid userGuid;
    }
    private class PrivateDto : BaseDto {
          AuthenticationTicket authTicket;
    }
