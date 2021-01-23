    public class MyAppUser
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        [FacebookFieldModifier("id({PAGE_ID})")]
        public FacebookGroupConnection<FacebookLike> Likes { get; set; }
        ...
    }
