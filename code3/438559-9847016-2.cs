    public class UserRoleSaveVM
    {
      public int UserID { get; set; }
      public int[] UserInRoles { get; set; } //note that property name is the same as checkbox name
      public int[] UserNotInRoles{ get; set; } //note that property name is the same as checkbox name
    }
