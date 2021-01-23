    public class ResetPasswordModel
    {
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string NewPassword { get; set; }
        [DataType(DataType.Password)]
        public string PasswordConfirmed { get; set; }
    }
