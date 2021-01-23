    [DataMember(Name = "StudentID")]
    public string StudentID { get; set; }
    [DataMember(Name = "FirstName")]
    public string FirstName { get; set; }
    [DataMember(Name = "LastName")]
    public string LastName { get; set; }
    [DataMember(Name = "Password")]
    public string Password;
    [DataMember(Name = "Salt")]
    public byte[] Salt;
    protected RNGCryptoServiceProvider random = new RNGCryptoServiceProvider();
    public byte[] GenerateSalt()
    {
        byte[] salt = new byte[10];
        random.GetNonZeroBytes(salt);
        return salt;
    } 
    public static byte[] Hash(string value, byte[] salt)
    {
        return Hash(Encoding.UTF8.GetBytes(value), salt);
    }
    public static byte[] Hash(byte[] value, byte[] salt)
    {
        byte[] saltedValue = value.Concat(salt).ToArray();
        return new SHA256Managed().ComputeHash(saltedValue);
    }
    public void AddStudent(Student student)
    {
        byte[] salt = GenerateSalt();
        
        student.StudentID = (++eCount).ToString();
        byte[] passwordHash = Hash(student.Password, salt);
        student.Salt = salt;
        student.Password = Convert.ToBase64String(passwordHash);
        student.TimeAdded = DateTime.Now;
        students.Add(student);
    }
