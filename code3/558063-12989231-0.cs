    public class Administrator
    {
    public int ID { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    private string password;
    public string Password
    {
        get
        {
            return this.password;
        }
        set
        {
            this.password = Infrastructure.Encryption.SHA256(value);
        }
    }
    }
