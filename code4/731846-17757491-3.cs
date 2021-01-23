    class DecoratedClass : AbstractDecoratedClass
    {
        [DbField("User_Id")]
        public int UserId { get; set; }
        [DbField("User_Id2")]
        public int UserId2 { get; set; } 
    }
